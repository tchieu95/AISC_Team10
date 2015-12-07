using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    class DoctorAccountDAO
    {
        DataProvider _provider = new DataProvider();

        public DoctorAccountDAO()
        {
            _provider.connect();
        }

        public void insert(DoctorAccountDTO info)
        {
            _provider.createStoreProcedure("AISC_TEAM10_PROC_DOCTOR_ACCOUNT_INSERT");
            _provider.addParamStoreProcedure("@UserID", info._username);
            _provider.addParamStoreProcedure("@HospitalName", info._hospitalName);
            _provider.addParamStoreProcedure("@WorkAddress", info._workaddress);
            _provider.addParamStoreProcedure("@Speciality", info._speciality);

            _provider.executeNonQuery_StoreProdedure();
        }
    }
}
