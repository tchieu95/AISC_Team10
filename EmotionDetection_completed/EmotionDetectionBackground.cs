using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Threading;

namespace AISC.EmotionDetection
{
    class EmotionDetectionBackground
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //
        private string[] EmotionLabels = { "ANGER", "CONTEMPT", "DISGUST", "FEAR", "JOY", "SADNESS", "SURPRISE" };
        private string[] SentimentLabels = { "NEGATIVE", "POSITIVE", "NEUTRAL" };

        public int NUM_EMOTIONS = 10;
        public int NUM_PRIMARY_EMOTIONS = 7;

        //
        public PXCMSession _session;

        public EmotionDetectionBackground(PXCMSession session)
        {
            _session = session;
            AllocConsole();
        }

        public void SimplePipeline()
        {
            bool sts = true;
            PXCMSenseManager pp = _session.CreateSenseManager();
            if (pp == null) throw new Exception("Failed to create sense manager");
            if (pp.captureManager == null) throw new Exception("Capture manager dose not exist");

            /* Set Module */
            pp.EnableEmotion();

            /* Initialization */
            Console.WriteLine("Init Started");

            PXCMSenseManager.Handler handler = new PXCMSenseManager.Handler()
            {
                //GZ onModuleQueryProfile = OnModuleQueryProfile
            };

            if (pp.Init(handler) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("Streaming");
                PXCMCaptureManager captureManager = pp.QueryCaptureManager();
                if (captureManager == null) throw new Exception("Failed to query capture manager");
                PXCMCapture.Device device = captureManager.QueryDevice();

                if (device != null)
                    device.SetDepthConfidenceThreshold(7);
                //GZ device.SetProperty(PXCMCapture.Device.Property.PROPERTY_DEPTH_CONFIDENCE_THRESHOLD, 7);                

                while (true)
                {
                    Thread.Sleep(1000);
                    if (pp.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                    if (pp.IsConnected())
                    {
                        /* Display Results */
                        PXCMEmotion ft = pp.QueryEmotion();
                        if (ft == null)
                        {
                            pp.ReleaseFrame();
                            continue;
                        }

                        //GZ DisplayPicture(pp.QueryImageByType(PXCMImage.ImageType.IMAGE_TYPE_COLOR));
                        PXCMCapture.Sample sample = pp.QueryEmotionSample();
                        if (sample == null)
                        {
                            pp.ReleaseFrame();
                            continue;
                        }

                        if (sample.color == null)
                            return;

                        DisplayEmotion(ft);
                    }
                    pp.ReleaseFrame();
                }
            }
            else
            {
                Console.WriteLine("Init Failed");
                sts = false;
            }

            pp.Close();
            pp.Dispose();
            if (sts) Console.WriteLine("Stopped");
        }

        private void DisplayEmotion(PXCMEmotion ft)
        {
            int numFaces = ft.QueryNumFaces();
            for (int i = 0; i < numFaces; i++)
            {
                /* Retrieve emotionDet location data */
                PXCMEmotion.EmotionData[] arrData = new PXCMEmotion.EmotionData[NUM_EMOTIONS];
                if (ft.QueryAllEmotionData(i, out arrData) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    Display(arrData);
                }
            }
        }

        private void Display(PXCMEmotion.EmotionData[] data)
        {
            bool emotionPresent = false;
            int epidx = -1;
            int maxscoreE = -3;
            float maxscoreI = 0;
            for (int i = 0; i < NUM_PRIMARY_EMOTIONS; i++)
            {
                if (data[i].evidence < maxscoreE) continue;
                if (data[i].intensity < maxscoreI) continue;
                maxscoreE = data[i].evidence;
                maxscoreI = data[i].intensity;
                epidx = i;
            }
            if ((epidx != -1) && (maxscoreI > 0.4))
            {                        
                emotionPresent = true;
            }

            int spidx = -1;
            if (emotionPresent)
            {
                maxscoreE = -3;
                maxscoreI = 0;
                for (int i = 0; i < (NUM_EMOTIONS - NUM_PRIMARY_EMOTIONS); i++)
                {
                    if (data[NUM_PRIMARY_EMOTIONS + i].evidence < maxscoreE) continue;
                    if (data[NUM_PRIMARY_EMOTIONS + i].intensity < maxscoreI) continue;
                    maxscoreE = data[NUM_PRIMARY_EMOTIONS + i].evidence;
                    maxscoreI = data[NUM_PRIMARY_EMOTIONS + i].intensity;
                    spidx = i;
                }
                if ((spidx != -1))
                {
                    string time = DateTime.Now.ToString("dd/MM/yyyy.HH:mm:ss");
                    Console.WriteLine(time + " : " + EmotionLabels[epidx]);
                    Console.WriteLine(time + " : " + SentimentLabels[spidx]);

                    EmotionDTO.prev_time = EmotionDTO.cur_time;
                    EmotionDTO.prev_sentiment = EmotionDTO.cur_sentiment;

                    EmotionDTO.cur_time = DateTime.Now;
                    EmotionDTO.cur_sentiment = SentimentLabels[spidx];
                }
            }
        }
    }
}
