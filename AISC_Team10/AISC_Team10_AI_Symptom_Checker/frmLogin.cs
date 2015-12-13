using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            (new frmRegister()).ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginInfo info = new LoginInfo();

            info.UserName = txtBoxUsername.Text;
            info.Password = txtBoxPassword.Text;

            LoginBUS loginBus = new LoginBUS();
            int role = loginBus.login(info);
            if (role >= 0)
            {
                this.DialogResult = DialogResult.OK;
                Program._accInfo._username = info.UserName;
                Program._accInfo._role = role;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error");
                return;
            }
        }

        private void lnkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new frmForgotPassword()).ShowDialog();
        }
    }
}
