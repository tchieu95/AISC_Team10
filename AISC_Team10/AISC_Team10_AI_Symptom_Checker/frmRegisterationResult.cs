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
    public partial class frmRegisterationResult : Form
    {
        public frmRegisterationResult(AccountDTO info)
        {
            InitializeComponent();
            info.showInfo(this);
        }
    }
}
