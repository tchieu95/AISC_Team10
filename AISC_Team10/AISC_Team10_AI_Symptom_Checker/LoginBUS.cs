using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace AISC_Team10_AI_Symptom_Checker
{
    class LoginBUS
    {
        DataProvider _provider = new DataProvider();

        public LoginBUS()
        {
            _provider.connect();
        }

        public bool login(LoginInfo info)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_LOGIN");
            _provider.addParamStoreProcedure("@UserID", info.UserName);
            _provider.addParamStoreProcedure("@UserPassword", info.Password);
            SqlParameter outputParam = new SqlParameter("@Succeed", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            _provider.addParamStoreProcedure(outputParam);
            _provider.executeNonQuery_StoreProdedure();

            return outputParam.Value.ToString() == "1";
        }
    }
}
