using AISC_Team10_Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class mainUserDAO
    {
        DataProvider _provider = new DataProvider();
        public void updateIP(string _userName, string _IP)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_UPDATE_IP");
            _provider.addParamStoreProcedure("@UserID", _userName);
            _provider.addParamStoreProcedure("@Ip", _IP);

            _provider.executeNonQuery_StoreProdedure();
        }

        public void releaseIP(string _username)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_RELEASE_IP");
            _provider.addParamStoreProcedure("@UserID", _username);
            _provider.executeNonQuery_StoreProdedure();
        }

        public AccountDTO[] getOnlineFriends(string _userName)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GETALL_IP_ONLINE_LINKED_ACC");
            _provider.addParamStoreProcedure("@UserID", _userName);
            DataTable dt = _provider.executeQuery_StoreProdedure();
            
            int i, n = dt.Rows.Count;
            AccountDTO[] arr = new AccountDTO[n];
            for (i = 0; i < n; i++)
            {
                string userID = dt.Rows[i]["UserID"].ToString();
                string ip = dt.Rows[i]["Ip"].ToString();
                AccountCTL ctl = new AccountCTL();
                AccountDTO info = ctl.getAccountInfo(userID);
                info._ip = ip;
                arr[i] = info;
            }
            return arr;
        }

        public void saveRecognitionData(string username, RecognitionResult _RecognitionResult)
        {
            float __usingTime = _RecognitionResult._usingTime;
            float __negative = _RecognitionResult.computeNegativeTimeSpan();
            float __neutral = _RecognitionResult.computeNormalTimeSpan();
            float __positive = _RecognitionResult.computePositiveTimeSpan();

            _provider.createStoreProcedure("AISC_TEAM10_PROC_UPDATE_HEALTH_DIALY_RECORD");
            _provider.addParamStoreProcedure("@UserID", username);
            _provider.addParamStoreProcedure("@Day", _RecognitionResult._time);
            _provider.addParamStoreProcedure("@UsingTime", __usingTime);
            _provider.addParamStoreProcedure("@HeartBeat", _RecognitionResult._heartBeat);
            _provider.addParamStoreProcedure("@Negative", __negative);
            _provider.addParamStoreProcedure("@Normal", __neutral);
            _provider.addParamStoreProcedure("@Positive", __positive);
            _provider.executeNonQuery_StoreProdedure();
        }

        public void sendLinkingRequest(string username_1, string username_2)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_INSERT_LINKING_REQUEST");
            _provider.addParamStoreProcedure("@UserID_1", username_1);
            _provider.addParamStoreProcedure("@UserID_2", username_2);
            _provider.executeNonQuery_StoreProdedure();
        }

        public string[] getAllLinkingRequests(string username)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GETALL_LINKING_REQUEST");
            _provider.addParamStoreProcedure("@UserID", username);
            DataTable dt = _provider.executeQuery_StoreProdedure();

            int i, n = dt.Rows.Count;
            string[] arr = new string[n];
            for (i = 0; i < n; i++)
            {
                string userID = dt.Rows[i]["UserID"].ToString();
                arr[i] = userID;
            }
            return arr;
        }

        public void acceptRequest(string username_1, string username_2)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_ACCEPT_LINKING_REQUEST");
            _provider.addParamStoreProcedure("@UserID_1", username_1);
            _provider.addParamStoreProcedure("@UserID_2", username_2);
            _provider.executeNonQuery_StoreProdedure();
        }

        public string[] getAllLinkedAccs(string username)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GETALL_LINKED_ACCOUNTS");
            _provider.addParamStoreProcedure("@UserID", username);
            DataTable dt = _provider.executeQuery_StoreProdedure();

            int i, n = dt.Rows.Count;
            string[] arr = new string[n];
            for (i = 0; i < n; i++)
            {
                string userID = dt.Rows[i]["UserID"].ToString();
                arr[i] = userID;
            }
            return arr;
        }

        public void unlinkAccount(string username_1, string username_2)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_UNLINK_ACCOUNT");
            _provider.addParamStoreProcedure("@UserID_1", username_1);
            _provider.addParamStoreProcedure("@UserID_2", username_2);
            _provider.executeNonQuery_StoreProdedure();
        }

        public string getHealthWarnings()
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GET_HEALTH_WARNINGS");
            DataTable dt = _provider.executeQuery_StoreProdedure();
            return dt.Rows[0]["_content"].ToString();
        }
    }
}
