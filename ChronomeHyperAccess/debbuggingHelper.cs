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
        public static void printarr(string[] strarr)
        {
            for (int z = 0; z < strarr.Length; z++)
            {
                Console.WriteLine("DEBUG---------");
                Console.WriteLine(strarr[z]);
                
            }
        }

        public static void print2d(string[,] strarr)
        {
            Console.WriteLine("panjang baris" + strarr.GetLength(0));
            for(int z = 0; z < strarr.GetLength(0); z++)
            {
                for(int x =0; x < strarr.GetLength(1); x++)
                {
                    Console.Write(strarr[z, x] + " - ");
                }
                Console.WriteLine();
            }
        }

        //Print all kind of objects/instance
        public static void print(Object apa_aja)
        {
            Console.WriteLine(apa_aja);
        }
    }
}
