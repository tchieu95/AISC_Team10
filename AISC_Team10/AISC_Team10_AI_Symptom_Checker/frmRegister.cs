using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AISC_Team10_AI_Symptom_Checker
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AccountDTO info = new AccountDTO();

            info._fullName = txtBoxFirstName.Text + " " + txtBoxLastName.Text;
            info._gender = cbBoxGender.Text;
            info._username = txtBoxUserName.Text;

            if (txtBoxPassword.Text == txtBoxConfirmPassword.Text)
            {
                info._password = txtBoxPassword.Text;
            }
            else
            {
                MessageBox.Show("Password is not matched!", "Error");
                return;
            }

            if (txtBoxEmail.Text == txtBoxEmailConfirm.Text)
            {
                info._email = txtBoxEmail.Text;
            }
            else
            {
                MessageBox.Show("Email is not matched!", "Error");
                return;
            }

            info._phoneNum = txtBoxPhoneNumber.Text;
            info._DoB = dtpDoB.Value.Date;
            info._address = txtBoxAddress.Text;

            AccountDAO dao = new AccountDAO();
            dao.insert(info);

            this.Close();
            (new frmRegisterationRoleChoice(info)).ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
