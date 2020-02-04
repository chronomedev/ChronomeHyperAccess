using System;
using System.Windows.Forms;
using System.IO;



// Chronome HyperAccess Code
// ChronomeDev 2020


namespace ChronomeHyperAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string[] namafile = Directory.GetFiles(@"c:\xampp\", "*",  SearchOption.TopDirectoryOnly);
            debug.printz(Konten.getAllDirectory(@"c:\xampp"));
            debug.printz(Konten.getAllFile(@"c:\xampp"));

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            about tentang = new about();
            tentang.ShowDialog();
        }
    }
}
