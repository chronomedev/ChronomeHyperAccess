using System;
using System.Windows.Forms;


namespace ChronomeHyperAccess
{

    // UI Handler 
    // This Class is created for handling operation of the User Interface
    // ID: Kelas yang dibuat digunakan untuk melakukan operasi tatap muka atau user interface
    // ChronomeDev 2020
    class UIHandler
    {
        public static void createTextBoxPanel(Panel kontener, int id_generated)
        {
            TextBox field = new TextBox();
            field.Name = "field" + id_generated;
            kontener.Controls.Add(field);
            //form1.Controls.Add(txt);
        }        
    }
}
