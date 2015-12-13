using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class AccountCTL
    {
        AccountDAO _dao = new AccountDAO();

        public void insert(AccountDTO info)
        {
            _dao.insert(info);
        }

        public AccountDTO getAccountInfo(string userName)
        {
            AccountDTO res = new AccountDTO();
            res = _dao.getAccountInfo(userName);
            return res;
        }
    }
}
