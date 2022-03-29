using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wukai1327Project3CLSApp
{
    public partial class frmCreative : Form
    {
        private Icon m_Ready=new Icon(SystemIcons.Information,40,40);

        public frmCreative()
        {
            InitializeComponent();
        }

        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "D:\\Creative\\Source\\";
            txtProcessedFile.Text = "D:\\Creative\\Processed\\";
            txtDest.Text = "D:\\Creative\\Destination\\";
            opsGenerateLog.Checked = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //source text box validatin
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");//no error

            //processedFile text box validatin
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid ProcessedFile Directory");
                txtProcessedFile.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile, "");//no error

            //destination text box validatin
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");//no error

            //end validatin

            //activate watching directory
            watchDir.EnableRaisingEvents = true;//start watching    
            watchDir.Path = txtDest.Text;   //D:\\Creative\\Source\\

            //code for notification 
            mnuNotify.Icon = m_Ready;   //set icon
            mnuNotify.Visible = true;      //show 
            this.ShowInTaskbar = true;  //hide in task bar
            this.Hide();
        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //valiadte source
            if (Directory.Exists(txtSource.Text))
                txtSource.BackColor = Color.White;//no error
            else
                txtSource.BackColor = Color.Pink;//error
        }

        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
            //valiadte destination
            if (Directory.Exists(txtDest.Text))
                txtDest.BackColor = Color.White;//no error
            else
                txtDest.BackColor = Color.Pink;//error
        }

        private void txtProcessedFile_TextChanged(object sender, EventArgs e)
        {
            //valiadte processed file
            if (Directory.Exists(txtProcessedFile.Text))
                txtProcessedFile.BackColor = Color.White;//no error
            else
                txtProcessedFile.BackColor = Color.Pink;//error
        }

        private void mnuConfigure_Click(object sender, EventArgs e)
        {
           mnuNotify.Visible=false;
            this.ShowInTaskbar=true;
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }
    }
    }
