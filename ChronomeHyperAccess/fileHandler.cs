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

        private const int _FILE_PROPERTY = 2;
        public static string[] getAllFile(String path_cari)
        {
            string[] list = Directory.GetFiles(path_cari, "*", SearchOption.TopDirectoryOnly);
            return list;
        }

        //Change path array dynamically to optimize memory
        public static string[] getAllDirectory(String path_cari)
        {
            string[] list = Directory.GetDirectories(@path_cari, "*", SearchOption.TopDirectoryOnly);
            return list;
        }
    
    }
}
