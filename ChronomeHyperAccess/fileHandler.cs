using System;
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
                listTemp[z, 1] = "0";
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
                listTemp[z, 1] = "0";
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
        public static string direktori_hta;

        public static void setDirectory(string direktori)
        {
            direktori_hta = direktori;
        }

        public static void createHTA()
        {
            
        }

        public static string[,] setRoute(string[,] arr, int index)
        {
            arr[index, 1] = "1";
            return arr;
        }

        public static string[,] clearRoute(string[,] arr, int index)
        {
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
