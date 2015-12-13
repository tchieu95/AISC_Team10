﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class RelativeAccountDAO
    {
        DataProvider _provider = new DataProvider();
 
        public RelativeAccountDAO()
        {
            _provider.connect();
        }

        public void insert(RelativeAccountDTO info)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_RELATIVE_ACCOUNT_INSERT");
            _provider.addParamStoreProcedure("@UserID", info._username);
            _provider.executeNonQuery_StoreProdedure();
        }

        public RelativeAccountDTO getAccountInfo(string userName)
        {
            RelativeAccountDTO res = new RelativeAccountDTO();
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GET_RELATIVE_ACCOUNT_INFO");
            _provider.addParamStoreProcedure("@UserID", userName);

            DataTable dt = _provider.executeQuery_StoreProdedure();
            if (dt == null)
            {
                return null;
            }

            res._email = dt.Rows[0]["Email"].ToString();
            res._gender = dt.Rows[0]["Gender"].ToString();
            res._fullName = dt.Rows[0]["FullName"].ToString();
            res._DoB = DateTime.Parse(dt.Rows[0]["DoB"].ToString());
            res._password = dt.Rows[0]["UserPassword"].ToString();
            res._username = dt.Rows[0]["UserID"].ToString();
            res._address = dt.Rows[0]["UserAddress"].ToString();
            res._phoneNum = dt.Rows[0]["Phone"].ToString();

            return res;
        }
    }
}
