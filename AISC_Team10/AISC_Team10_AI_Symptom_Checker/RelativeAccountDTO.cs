using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AISC_Team10_AI_Symptom_Checker
{
    public class RelativeAccountDTO : AccountDTO
    {
        public RelativeAccountDTO() { }
        public RelativeAccountDTO(AccountDTO info)
        {
            this._address = info._address;
            this._DoB = info._DoB;
            this._email = info._email;
            this._fullName = info._fullName;
            this._gender = info._gender;
            this._password = info._password;
            this._phoneNum = info._phoneNum;
            this._username = info._username;
        }
    }
}
