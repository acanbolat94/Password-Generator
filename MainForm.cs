using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SizeGripStyle = SizeGripStyle.Hide;
        }

        #region Variables
        int passNumber = 0;
        Random randomPassword = new Random();
        CheckBox chbox = new CheckBox();
        string createdRandomPassword = "";
        string passwordCharacters = "$-!@#ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        #endregion

        #region Methods
        private void CreatePassword(int passwordLength)
        {
            createdRandomPassword = "";
            for (int i = 0; i < passwordLength; i++)
            {
                passNumber = randomPassword.Next(0, passwordCharacters.Length);
                createdRandomPassword += passwordCharacters[passNumber].ToString();
                tboxPassword.Text = createdRandomPassword;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs keyEvent = new KeyEventArgs(keyData);

            if (keyEvent.Control && keyEvent.KeyCode == Keys.C) /*Control && keyEvent.KeyCode == Keys.C)*/
            {
                Clipboard.SetText(tboxPassword.Text);
                lblStatus.Text = "Password copied";
                lblStatus.ForeColor = Color.Green;
                lblStatus.BackColor = Color.White;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (cboxPasswordLength.SelectedItem != null)
            {
                CreatePassword(Convert.ToInt32(cboxPasswordLength.SelectedItem));
                lblStatus.Text = "Password created";
                lblStatus.ForeColor = Color.Green;
                lblStatus.BackColor = Color.White;
            }
            else
                MessageBox.Show("Password length cannot be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chboxLowercase.Checked = true;
            chboxNumbers.Checked = true;
            chboxSymbols.Checked = true;
            chboxUppercase.Checked = true;

            chboxLowercase.Enabled = false;
            chboxNumbers.Enabled = false;
            chboxSymbols.Enabled = false;
            chboxUppercase.Enabled = false;

            tboxPassword.Enabled = false;
            this.AcceptButton = btnCreate;

            tTipBtnCopyPassword.SetToolTip(btnCopyPassword, "Press CTRL+C to copy");
            tTipbtnCreatePassword.SetToolTip(btnCreate, "Press Enter to create a password");
        }

        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // copy text from textbox
                Clipboard.SetText(tboxPassword.Text);
                lblStatus.Text = "Password copied";
                lblStatus.ForeColor = Color.Green;
                lblStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Password is cannot be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}