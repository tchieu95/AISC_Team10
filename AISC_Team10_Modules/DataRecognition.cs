using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_Modules
{
    enum EMOTIONS { ANGER, CONTEMPT, DISGUST, FEAR, JOY, SADNESS, SURPRISE };

    enum SENTIMENTS { NEGATIVE, POSITIVE, NEUTRAL };

    public class DataRecognition
    {
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        //
        public string[] EmotionLabels = { "ANGER", "CONTEMPT", "DISGUST", "FEAR", "JOY", "SADNESS", "SURPRISE" };
        public string[] SentimentLabels = { "NEGATIVE", "POSITIVE", "NEUTRAL" };

        public int NUM_EMOTIONS = 10;
        public int NUM_PRIMARY_EMOTIONS = 7;

        //
        private OutDataDTO _outData;// = new OutDataDTO();
        private PXCMSession _session = PXCMSession.CreateInstance();
        //Form _appForm;
        private bool _stop = false;

        //
        public DataRecognition(ref OutDataDTO dto)
        {
            _session = PXCMSession.CreateInstance();
            if (_session != null)
            {
                // Optional steps to send feedback to Intel Corporation to understand how often each SDK sample is used.
                PXCMMetadata md = _session.QueryInstance<PXCMMetadata>();
                if (md != null)
                {
                    string sample_name = "Data Recognition";
                    md.AttachBuffer(1297303632, System.Text.Encoding.Unicode.GetBytes(sample_name));
                }
            }
            _outData = dto;
            //AllocConsole();
        }

        public void startEmotionDetectionForm()
        {
            (new EmotionDetection.EmotionDetectionForm(_session)).Show();
        }

        public void Stop()
        {
            _session.Dispose();
        }

        public void Start()
        {
            bool sts = true;

            PXCMSenseManager pp = _session.CreateSenseManager();
            if (pp == null) throw new Exception("Failed to create sense manager");

            PXCMCaptureManager captureManager = pp.QueryCaptureManager();
            if (captureManager == null) throw new Exception("Capture manager dose not exist");

            /* Set Module */
            pp.EnableEmotion();
            pp.EnableFace();

            /* Initialization */
            Console.WriteLine("Init Started");

            PXCMFaceModule faceModule = pp.QueryFace();
            if (faceModule == null)
            {
                Console.WriteLine("can't create faceModule.");
                return;
            }
            PXCMFaceConfiguration config = faceModule.CreateActiveConfiguration();
            if (config == null)
            {
                Console.WriteLine("can't create config");
                return;
            }
            //config.SetTrackingMode();
            config.ApplyChanges();

            PXCMCapture.Device.StreamProfileSet set = new PXCMCapture.Device.StreamProfileSet();
            //memset(&set, 0, sizeof(set));
            set.color.imageInfo.height = 720;
            set.color.imageInfo.width = 1280;
            captureManager.FilterByStreamProfiles(set);

            PXCMSenseManager.Handler handler = new PXCMSenseManager.Handler()
            {
                //GZ onModuleQueryProfile = OnModuleQueryProfile
            };

            if (pp.Init(handler) < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                captureManager.FilterByStreamProfiles(null);
                Console.WriteLine("Init Failed");
                sts = false;
                return;
            }
            else
            {
                PXCMCapture.DeviceInfo info;
                pp.QueryCaptureManager().QueryDevice().QueryDeviceInfo(out info);

                CheckForDepthStream(pp);
                config.QueryPulse().Enable();
                config.EnableAllAlerts();
                config.ApplyChanges();

                Console.WriteLine("Streaming");

                PXCMCapture.Device device = captureManager.QueryDevice();
                if (device != null)
                    device.SetDepthConfidenceThreshold(7);
                //GZ device.SetProperty(PXCMCapture.Device.Property.PROPERTY_DEPTH_CONFIDENCE_THRESHOLD, 7); 

                PXCMFaceData m_output = faceModule.CreateOutput();

                DateTime preTime = DateTime.Now;
                DateTime curTime = preTime.AddSeconds(1.0);

                while (!_stop)
                {
                    if (pp.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        pp.ReleaseFrame();
                        break;
                    }

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
                        PXCMCapture.Sample sample_emotion = pp.QueryEmotionSample();
                        m_output.Update();
                        PXCMCapture.Sample sample_heartBeat = pp.QueryFaceSample();

                        if (sample_emotion == null || sample_heartBeat == null)
                        {
                            pp.ReleaseFrame();
                            continue;
                        }

                        if (sample_emotion.color == null)
                            return;

                        curTime = DateTime.Now;
                        if (curTime.Subtract(preTime).TotalSeconds > 1.0)
                        {
                            _outData._time = curTime;
                            DisplayEmotion(ft);
                            if (m_output.QueryFaceByIndex(0) != null)
                            {
                                _outData._heartBeat = m_output.QueryFaceByIndex(0).QueryPulse().QueryHeartRate();
                            }
                            preTime = curTime;
                            //Console.WriteLine(_outData._time.ToString("dd.MM.yyyy.hh.mm.ss")
                            //    + " : " + _outData._emotion + " - " + _outData._sentiment + " - " + _outData._heartBeat);
                        }
                    }
                    pp.ReleaseFrame();
                }
            }

            pp.Close();
            pp.Dispose();
            if (sts) Console.WriteLine("Stopped");
        }

        private void DisplayEmotion(PXCMEmotion ft)
        {
            //int numFaces = ft.QueryNumFaces();
            //*************** just get 1 person
            int numFaces = 1;
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
                    _outData._emotion = EmotionLabels[epidx];
                    _outData._sentiment = SentimentLabels[spidx];
                }
            }
        }

        private void CheckForDepthStream(PXCMSenseManager pp)
        {
            PXCMFaceModule faceModule = pp.QueryFace();
            if (faceModule == null)
            {
                Console.WriteLine("can't create faceModule");
                return;
            }
            PXCMFaceConfiguration config = faceModule.CreateActiveConfiguration();
            if (config == null)
            {
                Console.WriteLine("can't create config");
                return;
            }

            PXCMFaceConfiguration.TrackingModeType trackingMode = config.GetTrackingMode();
        }

    }
}
