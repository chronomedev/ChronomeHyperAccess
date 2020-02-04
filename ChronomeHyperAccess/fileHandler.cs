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

        public static string[] getAllFile(String path_cari)
        {
            string[] list = Directory.GetFiles(path_cari, "*", SearchOption.TopDirectoryOnly);
            return list;
        }

        // Get latest path name
        //ambil nama belakang path
        public static string[] slice(string[] list_path)
        {
            string[] potong = new string[list_path.Length];
            for (int x = 0; x < list_path.Length; x++)
            {
                string[] pecah = list_path[x].Split('\\');
                potong[x] = pecah[pecah.Length-1]; 
            }
            return potong;
        }

        //Change path array dynamically to optimize memory
        public static string[] getAllDirectory(String path_cari)
        {
            string[] list = Directory.GetDirectories(@path_cari, "*", SearchOption.TopDirectoryOnly);
            return list;
        }

        public static int searchIndex(string path_cari, string[] list_path)
        {
            int index = 0;
            for(int z = 0; z < list_path.Length; z++)
            {
                if(list_path[z] == path_cari)
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

        public static Boolean checkExsist()
        {
            return true;
        }
    }
}
