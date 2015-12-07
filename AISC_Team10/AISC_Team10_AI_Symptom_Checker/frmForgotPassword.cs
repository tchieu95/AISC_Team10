using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ForgotPasswordDTO dto = new ForgotPasswordDTO();
            dto._username = txtBoxUsername.Text;
            dto._email = txtBoxEmail.Text;

            // gọi một web service nhận thông tin này
            // sau đó, gửi link reset password tới mail user
            // # nếu có thể thì dùng token và quản lý session chặt chẽ hơn.
            // # không thì xài link 1 lần, load lại là mất.
        }
    }
}
