using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class mainUserBUS
    {
        //public static OutDataDTO _OutDataDTO = new OutDataDTO();
        //public DataRecognition _DataRecognition = new DataRecognition(ref _OutDataDTO);
        mainUserDAO _dao = new mainUserDAO();
        System.Timers.Timer _timer = new System.Timers.Timer();

        public string updateIP(string _userName)
        {
            InternetProvider internetPvd = new InternetProvider();
            string ip = internetPvd.getInternetIPAddress();

            _dao.updateIP(_userName, ip);
            return ip;
        }

        public void startEmotionDetectionForm()
        {
            //_DataRecognition.StartEmotionTrackingForm();
        }

        public void setTimer(System.Timers.ElapsedEventHandler handler)
        {
            _timer = new System.Timers.Timer(10000); // 10 second
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(handler);
            _timer.Start();
        }

        public void releaseIP(string _username)
        {
            _dao.releaseIP(_username);
        }

        public AccountDTO[] getOnlineFriends(string _username)
        {
            return _dao.getOnlineFriends(_username);
        }
    }
}
