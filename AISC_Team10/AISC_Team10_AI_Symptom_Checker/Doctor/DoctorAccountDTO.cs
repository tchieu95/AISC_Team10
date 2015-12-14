using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public class DoctorAccountDTO : AccountDTO
    {
        public DoctorAccountDTO() { }

        public DoctorAccountDTO(AccountDTO info)
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

        public string _hospitalName { get; set; }
        public string _workaddress { get; set; }
        public string _speciality { get; set; }

        public override void showInfo(frmRegisterationResult frm)
        {
            base.showInfo(frm);
            GroupBox grpBox = (GroupBox) frm.Controls["grpBoxDoctorInfo"];
            grpBox.Visible = true;
            grpBox.Controls["lblHospital"].Text = _hospitalName;
            grpBox.Controls["lblWorkAddress"].Text = _workaddress;
            grpBox.Controls["lblSpeciality"].Text = _speciality;
        }
    }
}
