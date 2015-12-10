using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AISC
{
    class HeartbeatDetectionBackground
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        PXCMSession _session;

        public HeartbeatDetectionBackground(PXCMSession session)
        {
            _session = session;
            AllocConsole();
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

        public void Process()
        {
            PXCMSenseManager senseManager = _session.CreateSenseManager();
            if (senseManager == null)
            {
                Console.WriteLine("Failed to create an SDK SenseManager");
                return;
            }

            /* Set Mode & Source */
            PXCMCaptureManager captureManager = senseManager.QueryCaptureManager();

            /* Set Module */
            senseManager.EnableFace();

            /* Initialize */
            Console.WriteLine("Init Started");

            PXCMFaceModule faceModule = senseManager.QueryFace();
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

            /*	// set 60 fps camera
                PXCCapture::Device::StreamProfileSet set;
                memset(&set, 0, sizeof(set));
                set.color.imageInfo.height = 480;
                set.color.imageInfo.width = 640;	
                set.color.frameRate.min = 60; 
                set.color.frameRate.max = 60;
                set.color.imageInfo.format =  PXCImage::PIXEL_FORMAT_YUY2;

                set.depth.imageInfo.height = 480;
                set.depth.imageInfo.width = 640;	
                set.depth.frameRate.min = 60;
                set.depth.frameRate.max = 60;
                set.depth.imageInfo.format = PXCImage::PIXEL_FORMAT_DEPTH;

                captureManager->FilterByStreamProfiles(&set);*/


            PXCMCapture.Device.StreamProfileSet set = new PXCMCapture.Device.StreamProfileSet();
            //memset(&set, 0, sizeof(set));
            set.color.imageInfo.height = 720;
            set.color.imageInfo.width = 1280;
            captureManager.FilterByStreamProfiles(set);

            if (senseManager.Init() < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                captureManager.FilterByStreamProfiles(null);
                if (senseManager.Init() < pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    Console.WriteLine("Init Failed");
                    return;
                }
            }

            PXCMCapture.DeviceInfo info;
            senseManager.QueryCaptureManager().QueryDevice().QueryDeviceInfo(out info);
            /*if (info.model == PXCCapture::DEVICE_MODEL_DS4 && !FaceTrackingUtilities::GetPlaybackState(dialogWindow))
            {
                hr = senseManager->QueryCaptureManager()->QueryDevice()->SetDSLeftRightExposure(26);
                senseManager->QueryCaptureManager()->QueryDevice()->SetDepthConfidenceThreshold(0);
            }

            if(FaceTrackingUtilities::GetCheckedModule(dialogWindow) && info.model == PXCCapture::DEVICE_MODEL_IVCAM)
            {
                /*bool mirror = FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_MIRROR);
                if(mirror)
                {
                    captureManager->QueryDevice()->SetMirrorMode(PXCCapture::Device::MIRROR_MODE_HORIZONTAL);
                }
                else
                {
                    captureManager->QueryDevice()->SetMirrorMode(PXCCapture::Device::MIRROR_MODE_DISABLED);
                }
            }*/

            CheckForDepthStream(senseManager);
            //PXCMFaceData.AlertData target = new PXCMFaceData.AlertData();
//***            PXCMFaceConfiguration.OnFiredAlertDelegate handler = new PXCMFaceConfiguration.OnFiredAlertDelegate();

            config.QueryPulse().Enable();
            /*
            FaceTrackingAlertHandler alertHandler(dialogWindow);
            if (FaceTrackingUtilities::GetCheckedModule(dialogWindow))
            {
                config->detection.isEnabled = FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_LOCATION);
                config->landmarks.isEnabled = FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_LANDMARK);
                config->pose.isEnabled = FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_POSE);
                    FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_PULSE) ? config->QueryPulse()->Enable() : config->QueryPulse()->Disable();
			
                if (FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_EXPRESSIONS))
                {
                    config->QueryExpressions()->Enable();
                    config->QueryExpressions()->EnableAllExpressions();
                }
                else
                {
                    config->QueryExpressions()->DisableAllExpressions();
                    config->QueryExpressions()->Disable();
                }
                if (FaceTrackingUtilities::IsModuleSelected(dialogWindow, IDC_RECOGNITION))
                {
                    config->QueryRecognition()->Enable();
                }
               */
            config.EnableAllAlerts();
//***            config.SubscribeAlert(handler);

            config.ApplyChanges();
            //}

            Console.WriteLine("Streaming");
            PXCMFaceData m_output = faceModule.CreateOutput();

            bool isFinishedPlaying = false;
            //bool activeapp = true;
            //ResetEvent(renderer->GetRenderingFinishedSignal());

            while (true)
            {
                //Thread.Sleep(1000);
                if (senseManager.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    isFinishedPlaying = true;
                }

                if (isFinishedPlaying)
                {
                    senseManager.ReleaseFrame();
                }

                m_output.Update();
                PXCMCapture.Sample sample = senseManager.QueryFaceSample();

                if (sample != null)
                {
/***                    /*DWORD dwWaitResult;
                    dwWaitResult = WaitForSingleObject(ghMutex,	INFINITE);
                    if(dwWaitResult == WAIT_OBJECT_0)
                    {*/

                    //renderer->SetOutput(m_output);
                    float hr = m_output.QueryFaceByIndex(0).QueryPulse().QueryHeartRate();
                    string time = DateTime.Now.ToString("dd/MM/yyyy.HH:mm:ss");
                    Console.WriteLine(time + " : " + hr);
//***                    //if(!ReleaseMutex(ghMutex))
                    //{
                    //    throw "Failed to release mutex";
                    //    return;
                    //}
                }
                senseManager.ReleaseFrame();
            }

            /*if (activeapp != isActiveApp)
            {
                activeapp = isActiveApp;
                if (activeapp)
                {
                    FaceTrackingUtilities::SetStatus(dialogWindow, L"In focus", statusPart);
                    senseManager->PauseFace(false);
                    auto device = senseManager->QueryCaptureManager()->QueryDevice();
                    device->RestorePropertiesUponFocus();
                } else {
                    FaceTrackingUtilities::SetStatus(dialogWindow, L"Out of focus", statusPart);
                    senseManager->PauseFace(true);
                }
            }*/

/*          
            Console.WriteLine("Stopped");
            senseManager.Close();*/
        }
    }
}
