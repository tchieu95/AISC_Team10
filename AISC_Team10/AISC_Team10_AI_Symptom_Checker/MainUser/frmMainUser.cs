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
        const int USING_TIME_LIMIT = 10;
        private int _curUsingTime = 0;

        public AccountDTO _info;
        mainUserBUS _bus;
        AccountDTO[] _onlineFrdList;

        public frmMainUser(AccountDTO info)
        {
            InitializeComponent();
            _info = info;
            _bus = new mainUserBUS(this);
            _onlineFrdList = _bus.getOnlineFriends(_info._username);

            usrCtrlAvatar.Info = _info;

            _bus.updateIP(_info._username);
            _bus.setTimerUpdateFrdList(updateOnlineFrdList);
            _bus.setTimerRecognitionData();
            _bus.startRecognition();

            //***
            timerUpdateRequestCount.Start();
            timerUpdateUserState.Start();
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
            if (MessageBox.Show("Continue exitting!", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bus.stopRecognition();
                _bus.releaseIP(_info._username);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void linklblLinkAccMng_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new frmLinkingAccountMng(this)).ShowDialog();
        }

        private void timerUpdateRequestCount_Tick(object sender, EventArgs e)
        {
            int count = _bus.getAllLinkingRequests(_info._username).Length;
            linklblLinkAccMng.Text = "Linking Account - (" + count + ")";
        }

        private void timerUpdateUserState_Tick(object sender, EventArgs e)
        {
            var state = _bus.getCurRecognitionData();
            lblState.Text = state._time.ToString("hh.mm.ss") + " : " + state._heartBeat + " - " + state._emotion + " - " + state._sentiment;

            if (state._heartBeat > 0) { _curUsingTime++; }

            if (_curUsingTime > USING_TIME_LIMIT)
            {
                _curUsingTime = 0;
                MessageBox.Show("You have been using computer during last 30 minutes.\nPlease take a short rest.", "Warning");
            }
        }

        private void frmMainUser_Load(object sender, EventArgs e)
        {
            string warnings = _bus.getHealthWarnings();
            // chuỗi trả về từ server dùng # thay cho \n
            warnings = warnings.Replace("#", "\n");
            MessageBox.Show(warnings, "Health warnings!");
        }
    }
}
