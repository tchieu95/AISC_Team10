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
    public partial class frmRegisterationRoleChoice : Form
    {
        private AccountDTO _info = new AccountDTO();

        public frmRegisterationRoleChoice(AccountDTO info)
        {
            InitializeComponent();
            _info = info;
        }
        

        private void btnRelative_Click(object sender, EventArgs e)
        {
            RelativeAccountDAO dao = new RelativeAccountDAO();
            RelativeAccountDTO info = new RelativeAccountDTO(_info);
            dao.insert(info);
            this.Close();
            (new frmRegisterationResult(info)).ShowDialog();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            PatientAccountDAO dao = new PatientAccountDAO();
            PatientAccountDTO info = new PatientAccountDTO(_info);
            dao.insert(info);
            this.Close();
            (new frmRegisterationResult(info)).ShowDialog();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            grpBoxDoctorInfo.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoctorAccountDTO info = new DoctorAccountDTO(_info);
            info._hospitalName = txtBoxHospital.Text;
            info._workaddress = txtBoxAddress.Text;
            info._speciality = txtBoxSpeciality.Text;

            DoctorAccountDAO dao = new DoctorAccountDAO();
            dao.insert(info);
            this.Close();
            (new frmRegisterationResult(info)).ShowDialog();
        }
    }
}
