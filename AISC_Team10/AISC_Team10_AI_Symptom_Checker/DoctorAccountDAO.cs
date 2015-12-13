using System;
using System.Collections.Generic;
using System.Data;
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

        public DoctorAccountDTO getAccountInfo(string userName)
        {
            DoctorAccountDTO res = new DoctorAccountDTO();
            _provider.createStoreProcedure("AISC_TEAM10_PROC_GET_DOCTOR_ACCOUNT_INFO");
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
            res._hospitalName = dt.Rows[0]["HospitalName"].ToString();
            res._workaddress = dt.Rows[0]["WorkAddress"].ToString();
            res._speciality = dt.Rows[0]["Speciality"].ToString();
            
            return res;
        }
    }
}
