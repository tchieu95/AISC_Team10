using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class DoctorAccountCTL
    {
        DoctorAccountDAO _dao = new DoctorAccountDAO();

        public void insert(DoctorAccountDTO info)
        {
            _dao.insert(info);
        }

        public DoctorAccountDTO getAccountInfo(string userName)
        {
            DoctorAccountDTO res = new DoctorAccountDTO();
            res = _dao.getAccountInfo(userName);
            return res;
        }
    }
}
