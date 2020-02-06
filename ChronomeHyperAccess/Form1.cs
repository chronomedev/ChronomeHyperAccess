﻿using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Chronome HyperAccess Code
// ChronomeDev 2020

namespace ChronomeHyperAccess {
    public partial class Form1 : Form
    {

        // Public varibles used by worker threads and main thread
        public int progressBarProcess = 0;
        public int selectedIndexPath;
        public static Boolean t1Finished = false;
        public static string selectedConfig;
        public Boolean isOpenDialog = false;

        public string direktori_pilihan;
        public string[,] list_direktori;
        public string[,] list_file;

        //public string[] list_direktori

        Thread t1;
        Thread t2;
        public Form1()
        {
            InitializeComponent();
            initializeThread();
            showParamUI(false);
        }

        //Thread Configuration Functions////////////////////////////////////////////////////////
        public void initializeThread()
        {
            t1 = new Thread(new ThreadStart(T_threadPathSearch));
            t2 = new Thread(new ThreadStart(T_ThreadProgressBarUpdate));
        }
        private void T_threadPathSearch()
        {
            list_direktori = Konten.getAllDirectory(direktori_pilihan);
            progressBarProcess = 30;
            list_file = Konten.getAllFile(direktori_pilihan);
            progressBarProcess = 60;

            // swap variables with slice one
            // 1 is store is routed, 2 is parameter content
            //string[,] dirTemp = new string[list_direktori.Length, 3];
            list_direktori = Konten.slice(list_direktori);
            list_file = Konten.slice(list_file);
            //list_direktori = null;
            debug.print2d(list_file);
            //debug.printarr(list_file);
            progressBarProcess = 100;
            t1Finished = true;
        }

        //Progressbar Control Thread
        private void T_ThreadProgressBarUpdate()
        {

            while (!t1Finished)
            {
                progressBar1.Invoke((Action)delegate
                {
                    progressBar1.Value = progressBarProcess;
                });
            }

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////

        public void updatePathDirectoryBox()
        {

            listBox1.Items.Clear();
            if (list_direktori.GetLength(0) == 0)
            {
                listBox1.Items.Add("EMPTY");
            }
            else
            {
                for (int z = 0; z < list_direktori.GetLength(0); z++)
                {
                    listBox1.Items.Add(list_direktori[z,0]);
                }
            }


        }


        public void showParamUI(Boolean show)
        {
            textBox3.Visible = show;
            label7.Visible = show;
        }

        public void updatePathFileBox()
        {
            listBox2.Items.Clear();
            if (list_file.GetLength(0) == 0)
            {
                listBox2.Items.Add("EMPTY");
            }
            else
            {

                for (int x = 0; x < list_file.GetLength(0); x++)
                {
                    listBox2.Items.Add(list_file[x,0]);
                }
            }

        }

        //turn the checkbox htaccess configuration on or off
        public void checkStatus(string tipe)
        {
            if(tipe == "dir")
            {
                if(list_direktori[selectedIndexPath, 1] == "1")
                {
                    checkBox1.Checked = true;
                } else
                {
                    checkBox1.Checked = false;
                }

                if(list_direktori[selectedIndexPath, 2] == null || list_direktori[selectedIndexPath, 2] == "")
                {
                    checkBox2.Checked = false;
                } else
                {
                    checkBox2.Checked = true;
                }
            } else
            {
                if (list_file[selectedIndexPath, 1] == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                if (list_file[selectedIndexPath, 2] == null || list_file[selectedIndexPath, 2] == "")
                {
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox2.Checked = true;
                }
            }
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
            Form1 formduplikat = new Form1();
            formduplikat.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            about tentang = new about();
            tentang.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(textBox1.Text == null || textBox1.Text == "")
            //{
            //    MessageBox.Show("Fill the directory Field!");
            //} else
            //{
            //try
            //{
            t1Finished = false;
            progressBar1.Value = 0;
            FolderBrowserDialog dialokDirektori = new FolderBrowserDialog();
            //OpenFileDialog dialokDirektori = new OpenFileDialog();
            if (dialokDirektori.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialokDirektori.SelectedPath;
                direktori_pilihan = textBox1.Text;
                initializeThread();
                t1.Start();
                t2.Start();
                loadingDialog loading1 = new loadingDialog();
                while (t1.IsAlive)
                {

                    if (isOpenDialog == false)
                    {

                        loading1.ShowDialog();
                        isOpenDialog = true;

                    }
                }
                //progressBarProcess = 0;
                debug.print("okeeee");
                updatePathDirectoryBox();
                updatePathFileBox();

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexPath = Konten.searchIndex(listBox1.SelectedItem.ToString(), list_direktori);
            debug.print(selectedIndexPath);
            checkStatus("dir");
            selectedConfig = "dir";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexPath = Konten.searchIndex(listBox2.SelectedItem.ToString(), list_file);
            debug.print(selectedIndexPath);
            checkStatus("f");
            selectedConfig = "f";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                showParamUI(true);
            } else
            {
                showParamUI(false);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(selectedConfig == "dir")
            {
                list_direktori = htaccess.setRoute(list_direktori, selectedIndexPath);
                debug.print2d(list_direktori);
            } else
            {
                list_file = htaccess.setRoute(list_file, selectedIndexPath);
                debug.print2d(list_file);
            }
        }
    }
}