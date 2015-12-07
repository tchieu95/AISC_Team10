using System;
using System.Collections.Generic;
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
    }
}
