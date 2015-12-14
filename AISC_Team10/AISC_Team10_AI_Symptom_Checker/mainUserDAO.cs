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
    }
}
