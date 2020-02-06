﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChronomeHyperAccess
{

    /// <summary>
    /// File Handler Class
    /// Utilizing all IO system library
    /// ChronomeDev 2020
    /// </summary>
    static class Konten
    {

        public static string[,] getAllFile(String path_cari)
        {

            string[] list = Directory.GetFiles(path_cari, "*", SearchOption.TopDirectoryOnly);
            string[,] listTemp = new string[list.Length, 3];
            for (int z = 0; z < list.Length; z++)
            {
                listTemp[z, 0] = list[z];
                listTemp[z, 1] = null;
                listTemp[z, 2] = null;
            }
            return listTemp;
        }

        //Change path array dynamically to optimize memory
        public static string[,] getAllDirectory(String path_cari)
        {
            string[] list = Directory.GetDirectories(@path_cari, "*", SearchOption.TopDirectoryOnly);
            string[,] listTemp = new string[list.Length, 3];
            for (int z = 0; z < list.Length; z++)
            {
                listTemp[z, 0] = list[z];
                listTemp[z, 1] = null;
                listTemp[z, 2] = null;
            }
            return listTemp;
        }

        // Get latest path name
        //ambil nama belakang path
        public static string[,] slice(string[,] list_path)
        {
          
            string[,] potong = list_path; 
            for (int x = 0; x < list_path.GetLength(0); x++)
            {
                debug.print(x);
                string[] pecah = list_path[x,0].Split('\\');
                potong[x,0] = pecah[pecah.Length-1]; 
            }
            return potong;
        }



        public static int searchIndex(string path_cari, string[,] list_path)
        {
            int index = 0;
            for(int z = 0; z < list_path.Length; z++)
            {
                if(list_path[z,0] == path_cari)
                {
                    index = z;
                    break;
                }
            }
            return index;
        }


    
    }

    //htaccess write ops class
    static class htaccess
    {

        //ublic static string script_generated = "";
        public static string direktori_hta;

        public static void setDirectory(string direktori)
        {
            direktori_hta = direktori;
        }

        public static void createHTA()
        {

        }

        public static string[] parameterCleansing(string parameter_masuk)
        {
            string[] pecah = parameter_masuk.Split('&');
            return pecah;
        }
        public static string generateScript(string[,] list_direktori, string[,] list_file)
        {
            string script_generated = "";
            // Write for directory first
            for(int z = 0; z < list_direktori.GetLength(0); z++)
            {
                debug.print("hahahahahaha--->" + list_direktori[z, 2]);
                if(list_direktori[z, 1] == null)
                {
                    debug.print("TRUE");
                } else
                {
                    debug.print("FALSE");
                }
                // If there is only basic routing
                if (list_direktori[z, 1] != null && (list_direktori[z, 2] == null || list_direktori[z, 2] == ""))
                {
                    script_generated = script_generated + "RewriteRule ^" + list_direktori[z, 1] + "?$ /" + list_direktori[z, 0] + " [L]\n";
                }
                else if (list_direktori[z, 1] == null || list_direktori[z, 1] == "" ) {

                    continue;
                } else // if there are parameter routes
                {
                    debug.print("LOOP DIREK" + z);
                    string[] paramcreated = parameterCleansing(list_direktori[z, 2]);
                    string param_cleansed = "";
                    for(int a = 0; a< paramcreated.Length; a++)
                    {
                        param_cleansed = param_cleansed + "/([^/\\.]+)";
                        
                    }
                    script_generated = script_generated + "RewriteRule ^" + list_direktori[z, 1] + param_cleansed + "?$ " + list_direktori[z, 0] + " [L]\n"; ;
                }
            }

            //Write for Files
            for (int z = 0; z < list_file.GetLength(0); z++)
            {
                // If there is only basic routing
                if (list_file[z, 1] != null && (list_file[z, 2] == null || list_file[z, 2] == ""))
                {
                    script_generated = script_generated + "RewriteRule ^" + list_file[z, 1] + "?$ " + list_file[z, 0] + " [L]\n";
                }
                else if (list_file[z, 1] == null || list_file[z, 1] == "") {
                    continue;

                } else // if there are parameter routes
                {
                    debug.print("LOOP FILE" + z);
                    string[] paramcreated = parameterCleansing(list_file[z, 2]);
                    string param_cleansed = "";
                    string param_putend_url = "?";
                    for (int a = 1; a < paramcreated.Length; a++)
                    {
                        param_cleansed = param_cleansed + "/([^/\\.]+)";
                        if(a + 1 != paramcreated.Length)
                        {
                            param_putend_url = param_putend_url + paramcreated[a] + "=$" + a + "&";
                        }
                        else
                        {
                            param_putend_url = param_putend_url + paramcreated[a] + "=$" + a;
                        }
                        

                    }
                    script_generated = script_generated + "RewriteRule ^" + list_file[z, 1] + param_cleansed + "?$ " + list_file[z, 0] + param_putend_url + " [L]\n";
                }
            }
            return script_generated;
        }

        public static string[,] setRoute(string[,] arr, int index, string param_masuk)
        {
            arr[index, 1] = param_masuk;
            return arr;
        }

        public static string[,] clearRoute(string[,] arr, int index)
        {
            arr[index, 1] = null;
            return arr;
        }

        public static string[,] setParam(string[,] arr, int index, string masukan_param)
        {
            arr[index, 2] = masukan_param;
            return arr;
        }

        public static string[,] clearParam(string[,] arr, int index)
        {
            arr[index, 2] = null;
            return arr;
        }




        public static Boolean checkExsist()
        {
            return true;
        }
    }
}
