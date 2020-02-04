using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Chronome HyperAccess Code
// ChronomeDev 2020

namespace ChronomeHyperAccess {
    public partial class Form1 : Form {

        // Public varibles used by worker threads and main thread
        public int progressBarProcess = 0;
        public Boolean t1Finished = false;
        public Boolean isOpenDialog = false;
        public string direktori_pilihan;
        public string[] list_direktori;
        public string[] list_file;
        Thread t1;
        Thread t2;
        public Form1 () {
            InitializeComponent ();
            initializeThread ();
            //string[] namafile = Directory.GetFiles(@"c:\xampp\", "*",  SearchOption.TopDirectoryOnly);
            //debug.printarr(Konten.getAllDirectory(@"c:\xampp"));
            //debug.printarr(Konten.getAllFile(@"c:\xampp"));

        }

        //Thread Configuration Functions////////////////////////////////////////////////////////
        public void initializeThread () {
            t1 = new Thread (new ThreadStart (T_threadDirectorySearch));
            t2 = new Thread (new ThreadStart (T_ThreadProgressBarUpdate));
        }
        private void T_threadDirectorySearch () {
            progressBarProcess = 0;
            list_direktori = Konten.getAllDirectory (direktori_pilihan);
            progressBarProcess = 30;
            list_file = Konten.getAllFile (direktori_pilihan);
            progressBarProcess = 60;
            debug.printarr (list_file);
            progressBarProcess = 100;
            t1Finished = true;
        }

        //Progressbar Control Thread
        private void T_ThreadProgressBarUpdate () {
            progressBar1.Invoke ((Action) delegate {
                progressBar1.Value = progressBarProcess;
            });
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        private void exitToolStripMenuItem_Click (object sender, EventArgs e) {
            Application.Exit ();
        }

        private void aboutToolStripMenuItem_Click (object sender, EventArgs e) {

        }

        private void newInstanceToolStripMenuItem_Click (object sender, EventArgs e) {
            Form1 formduplikat = new Form1 ();
            formduplikat.Show ();
        }

        private void aboutToolStripMenuItem1_Click (object sender, EventArgs e) {
            about tentang = new about ();
            tentang.ShowDialog ();
        }

        private void button1_Click (object sender, EventArgs e) {
            //if(textBox1.Text == null || textBox1.Text == "")
            //{
            //    MessageBox.Show("Fill the directory Field!");
            //} else
            //{
            //try
            //{
            t1Finished = false;
            FolderBrowserDialog dialokDirektori = new FolderBrowserDialog ();
            //OpenFileDialog dialokDirektori = new OpenFileDialog();
            if (dialokDirektori.ShowDialog () == DialogResult.OK) {
                textBox1.Text = dialokDirektori.SelectedPath;
                direktori_pilihan = textBox1.Text;
                initializeThread();
                t1.Start ();
                t2.Start ();
                while (t1.IsAlive) {

                    if (t1Finished) {

                        break;
                    } else if (isOpenDialog) {

                    }
                }
                //progressBarProcess = 0;
                debug.print("okeeee");
            }

            //} catch(Exception kacau)
            //{
            //        MessageBox.Show("ERROR! Error code : " + e);
            //MessageBox.Show("Apa bila menemukan bug atau error silahkan kontak Developer\nIf you found any defects or any error including the code, " +
            //    "please contact the developer :D");
            //        debug.print(e);
            //        debug.print("ERROR MESSAGE--\n" + kacau.Message);
            //}
        }

        private void label4_Click (object sender, EventArgs e) {

        }
    }
}