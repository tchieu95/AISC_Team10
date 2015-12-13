using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    enum ROLES { PATIENT, DOCTOR, RELATIVE};

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static AccountDTO _accInfo = new AccountDTO();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fLogin = new frmLogin();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                AccountDAO dao = new AccountDAO();
                AccountDTO info = dao.getAccountInfo(_accInfo._username);
                Application.Run(new frmMainUser(info));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
