using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class PatientAccountCTL
    {
        PatientAccountDAO _dao = new PatientAccountDAO();

        public void insert(PatientAccountDTO info)
        {
            _dao.insert(info);
        }

        public PatientAccountDTO getAccountInfo(string userName)
        {
            PatientAccountDTO res = new PatientAccountDTO();
            res = _dao.getAccountInfo(userName);
            return res;
        }
    }
}
