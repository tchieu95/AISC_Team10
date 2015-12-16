using AISC_Team10_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    class mainUserBUS
    {
        private static OutDataDTO _OutDataDTO = new OutDataDTO();
        private DataRecognition _DataRecognition = new DataRecognition(ref _OutDataDTO);
        private RecognitionResult _RecognitionResult = new RecognitionResult();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        bool _showCMD = false;
        mainUserDAO _dao = new mainUserDAO();
        System.Timers.Timer _timerUpdateFrdList;
        System.Timers.Timer _timerRecognitionData;
        Thread _recognitionThread;
        frmMainUser _form;

        public mainUserBUS(frmMainUser frm)
        {
            _form = frm;
        }

        public OutDataDTO getCurRecognitionData()
        {
            return _OutDataDTO;
        }

        public void acceptRequest(string username_1, string username_2)
        {
            _dao.acceptRequest(username_1, username_2);
        }

        public string updateIP(string _userName)
        {
            InternetProvider internetPvd = new InternetProvider();
            string ip = internetPvd.getInternetIPAddress();

            _dao.updateIP(_userName, ip);
            return ip;
        }

        public void startEmotionDetectionForm()
        {
            _DataRecognition.startEmotionDetectionForm();
        }

        public void setTimerRecognitionData()
        {
            _timerRecognitionData = new System.Timers.Timer(1000);
            _timerRecognitionData.Elapsed += new System.Timers.ElapsedEventHandler(updateRecognitionData);
        }

        public void startRecognition(bool showCMD = false)
        {
            _showCMD = showCMD;
            _recognitionThread = new Thread(Recognition);
            if (_recognitionThread != null)
            {
                _recognitionThread.Start();
                _timerRecognitionData.Start();
            }
        }

        private void Recognition(object obj)
        {
            if (_showCMD == true) { AllocConsole(); }
            _DataRecognition.Start();
        }

        public void stopRecognition()
        {
            
            if (_recognitionThread != null)
            {
                _timerRecognitionData.Stop();
                _DataRecognition.Stop();
                _recognitionThread.Abort();
                saveRecognitionData();
            }
        }

        private void updateRecognitionData(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_showCMD)
            {
                Console.WriteLine(_OutDataDTO._time.ToString("hh.mm.ss") + " : " + _OutDataDTO._heartBeat + " - " + _OutDataDTO._emotion + " - " + _OutDataDTO._sentiment);
            }
            _RecognitionResult.updateData(_OutDataDTO._heartBeat, _OutDataDTO._emotion, _OutDataDTO._sentiment);
        }
        
        public void saveRecognitionData()
        {
            string userName = Program._gblAccInfo._username;
            _dao.saveRecognitionData(userName, _RecognitionResult);
        }

        public void setTimerUpdateFrdList(System.Timers.ElapsedEventHandler handler)
        {
            _timerUpdateFrdList = new System.Timers.Timer(10000); // 10 seconds
            _timerUpdateFrdList.Elapsed += new System.Timers.ElapsedEventHandler(handler);
            _timerUpdateFrdList.Start();
        }

        public void releaseIP(string _username)
        {
            _dao.releaseIP(_username);
        }

        public AccountDTO[] getOnlineFriends(string _username)
        {
            return _dao.getOnlineFriends(_username);
        }

        public void sendLinkingRequest(string username_1, string username_2)
        {
            _dao.sendLinkingRequest(username_1, username_2);
        }

        public string[] getAllLinkingRequests(string username)
        {
            return _dao.getAllLinkingRequests(username);
        }

        public string[] getAllLinkedAccs(string username)
        {
            return _dao.getAllLinkedAccs(username);
        }

        public void unlinkAccount(string username_1, string username_2)
        {
            _dao.unlinkAccount(username_1, username_2);
        }

        public string getHealthWarnings()
        {
            return _dao.getHealthWarnings();
        }
    }
}
