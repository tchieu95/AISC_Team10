using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public class AccountDTO
    {
        public string _email { get; set; }
        public string _gender { get; set; }
        public string _fullName { get; set; }
        public DateTime _DoB { get; set; }

        public string _password { get; set; }
        public string _username { get; set; }
        public string _address { get; set; }
        public string _phoneNum { get; set; }

        public int _role { get; set; }
        public string _ip { get; set; }

        public virtual void showInfo(frmRegisterationResult frm)
        {
            frm.Controls["lblFullName"].Text = _fullName;
            frm.Controls["lblGender"].Text = _gender;
            frm.Controls["lblUsername"].Text = _username;
            frm.Controls["lblPassword"].Text = _password;
            frm.Controls["lblEmail"].Text = _email;
            frm.Controls["lblPhoneNum"].Text = _phoneNum;
            frm.Controls["lblDoB"].Text = _DoB.ToShortDateString();
            frm.Controls["lblAddress"].Text = _address;
        }
    }
}
