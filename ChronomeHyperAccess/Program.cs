using System;
using System.Windows.Forms;

namespace ChronomeHyperAccess
{
    static class Program
    {
        /// <summary>
        /// Main Fumction
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
