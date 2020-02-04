using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Class for Debugging Purposes
// ChronomeDev 2020

namespace ChronomeHyperAccess
{
    static class debug
    {
        public static void printz(string[] strarr)
        {
            for (int z = 0; z < strarr.Length; z++)
            {
                Console.WriteLine("DEBUG---------");
                Console.WriteLine(strarr[z]);
            }
        }
    }
}
