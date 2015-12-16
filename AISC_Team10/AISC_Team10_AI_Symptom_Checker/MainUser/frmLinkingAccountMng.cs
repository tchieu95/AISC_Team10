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
    public partial class frmLinkingAccountMng : Form
    {
        frmMainUser _mainForm;
        mainUserBUS _bus;
        ListView.ListViewItemCollection _collectionRequests;
        ListView.ListViewItemCollection _collectionLinkedAcc;

        public frmLinkingAccountMng(frmMainUser frm)
        {
            InitializeComponent();
            _mainForm = frm;
            _bus = new mainUserBUS(_mainForm);
            _collectionRequests = new ListView.ListViewItemCollection(lstViewRequestList);
            _collectionLinkedAcc = new ListView.ListViewItemCollection(lstViewLinkedAccs);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLinkingRequests_Load(object sender, EventArgs e)
        {
            string username = _mainForm._info._username;
            string[] listUserID = _bus.getAllLinkingRequests(username);
            
            for (int i = 0; i < listUserID.Length; i++)
            {
                _collectionRequests.Add(listUserID[i]);
            }

            listUserID = _bus.getAllLinkedAccs(_mainForm._info._username);
            for (int i = 0; i < listUserID.Length; i++)
            {
                _collectionLinkedAcc.Add(listUserID[i]);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lstViewRequestList.SelectedItems.Count == 0) {return;}

            string userID = lstViewRequestList.SelectedItems[0].Text;
            _bus.acceptRequest(userID, _mainForm._info._username);
            foreach (ListViewItem i in _collectionRequests)
            {
                if (i.Text == userID)
                {
                    _collectionLinkedAcc.Add(i.Text);
                    _collectionRequests.Remove(i);
                }
            }
            MessageBox.Show(userID + " is now linked!", "Noti");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstViewLinkedAccs.SelectedItems.Count == 0) { return; }

            string userID = lstViewLinkedAccs.SelectedItems[0].Text;
            _bus.unlinkAccount(userID, _mainForm._info._username);
            foreach (ListViewItem i in _collectionLinkedAcc)
            {
                if (i.Text == userID)
                {
                    _collectionLinkedAcc.Remove(i);
                }
            }
            MessageBox.Show(userID + " is now unlinked!", "Noti");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text;
            if (userID != "")
            {
                string username = _mainForm._info._username;
                _bus.sendLinkingRequest(username, userID);
                MessageBox.Show("Request sent!", "Noti");
                txtUserID.Text = "";
            }
        }
    }
}
