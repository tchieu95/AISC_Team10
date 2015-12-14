using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class AccountDAO
    {
        DataProvider _provider = new DataProvider();
 
        public AccountDAO()
        {
            _provider.connect();
        }

        public void insert(AccountDTO info)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_ACCOUNT_INSERT");
            _provider.addParamStoreProcedure("@Email", info._email);
            _provider.addParamStoreProcedure("@Sex", info._gender);
            _provider.addParamStoreProcedure("@FullName", info._fullName);
            _provider.addParamStoreProcedure("@DoB", info._DoB);
            _provider.addParamStoreProcedure("@UserPassword", info._password);
            _provider.addParamStoreProcedure("@UserID", info._username);
            _provider.addParamStoreProcedure("@UserAddress", info._address);
            _provider.addParamStoreProcedure("@Phone", info._phoneNum);

            _provider.executeNonQuery_StoreProdedure();
        }

        public void update(AccountDTO info, AccountDTO newInfo)
        {
            
        }

        public void delete(AccountDTO info)
        {
            
        }

        public void search(ref AccountDTO info)
        {
            
        }

        public AccountDTO getAccountInfo(string userName)
        {
            AccountDTO res = new AccountDTO();
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GET_ACCOUNT_INFO");
            _provider.addParamStoreProcedure("@UserID", userName);

            DataTable dt = _provider.executeQuery_StoreProdedure();
            if (dt == null)
            {
                return null;
            }

            res._email = dt.Rows[0]["Email"].ToString();
            res._gender = dt.Rows[0]["Sex"].ToString();
            res._fullName = dt.Rows[0]["FullName"].ToString();
            res._DoB = DateTime.Parse(dt.Rows[0]["DoB"].ToString());
            res._password = dt.Rows[0]["UserPassword"].ToString();
            res._username = dt.Rows[0]["UserID"].ToString();
            res._address = dt.Rows[0]["UserAddress"].ToString();
            res._phoneNum = dt.Rows[0]["Phone"].ToString();

            return res;
        }

        public DataTable getAllAccounts()
        {
            return null;
        }
    }
}
