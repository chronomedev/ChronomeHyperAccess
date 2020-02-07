using System;
using System.Windows.Forms;


// Loading dialog UI class
// Depends first directory and file searcher thread
// ChronomeDev 2020

namespace ChronomeHyperAccess
{
    public partial class loadingDialog : Form
    {
        public loadingDialog()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void loadingDialog_Load(object sender, EventArgs e)
        {
            while (Form1.t1Finished == false)
            {
                debug.print("loop!!!");
                continue;
            }
            this.Close();
        }
    }
}