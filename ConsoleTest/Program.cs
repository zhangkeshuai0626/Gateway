using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "0001121404";
            string ch = "00011214";

            int n = s1.IndexOf(ch)+ch.Length;
            string str = s1.Substring(n);
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
