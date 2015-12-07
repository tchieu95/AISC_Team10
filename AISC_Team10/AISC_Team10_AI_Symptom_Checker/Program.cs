using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AISC_Team10_AI_Symptom_Checker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin fLogin = new frmLogin();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMainUser());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
