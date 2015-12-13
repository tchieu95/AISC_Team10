using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public partial class usrCtrlAvatar : UserControl
    {
        AccountDTO _info;
        public AccountDTO Info 
        {
            get {return _info;}
            set
            {
                _info = value;
                setInfo();
            }
        }

        public usrCtrlAvatar()
        {
            InitializeComponent();
            
        }

        private void setInfo()
        {
            lblFullName.Text = _info._fullName;
            switch (_info._role)
            {
                case (int) ROLES.PATIENT:
                    ptcRole.Image = Properties.Resources.img_role_relative;
                    break;
                case (int)ROLES.RELATIVE:
                    ptcRole.Image = Properties.Resources.img_role_relative;
                    break;
                case (int)ROLES.DOCTOR:
                    ptcRole.Image = Properties.Resources.img_role_doctor;
                    break;
                default:
                    break;
            }
        }


    }
}
