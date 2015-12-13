using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class RelativeAccountCTL
    {
        RelativeAccountDAO _dao = new RelativeAccountDAO();

        public void insert(RelativeAccountDTO info)
        {
            _dao.insert(info);
        }

        public RelativeAccountDTO getAccountInfo(string userName)
        {
            RelativeAccountDTO res = new RelativeAccountDTO();
            res = _dao.getAccountInfo(userName);
            return res;
        }
    }
}
