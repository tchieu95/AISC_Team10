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
    public partial class frmMainUser : Form
    {
        AccountDTO _info;
        mainUserBUS _bus = new mainUserBUS();
        AccountDTO[] _onlineFrdList;

        public frmMainUser(AccountDTO info)
        {
            InitializeComponent();
            _info = info;
            _onlineFrdList = _bus.getOnlineFriends(_info._username);

            usrCtrlAvatar.Info = _info;

            _bus.updateIP(_info._username);
            _bus.setTimer(updateOnlineFrdList);
        }

        private void updateOnlineFrdList(object sender, System.Timers.ElapsedEventArgs e)
        {
            _onlineFrdList = _bus.getOnlineFriends(_info._username);
            // show ra listview
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmAbout()).ShowDialog();
        }

        private void frmMainUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bus.releaseIP(_info._username);   
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
