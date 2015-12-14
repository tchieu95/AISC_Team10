using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public class LoginInfo
    {
        string _userName;
        string _password;
        public string UserName 
        { 
            get
            {
                return _userName;
            }
            set 
            {
                if (value.Length == 0) 
                {
                    MessageBox.Show("Invalid username", "Error");
                    return;
                }
                _userName = value;
            }
        }
        public string Password
        { 
            get
            {
                return _password;
            }
            set
            {
                if (value.Length == 0)
                {
                    MessageBox.Show("Invalid password", "Error");
                    return;
                }
                _password = value;
            }
        }
    }
}
