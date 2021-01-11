using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _010_1正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "user827778732";
            string patt = @"user\d{8,15}$";
            string patt2 = @"^password\S{8-15}$";

            Console.WriteLine(Regex.Match(str,patt));
            Console.WriteLine("---------");
            
            foreach (Match item in Regex.Matches(str,patt))
            {
                Console.Write(item.Value);
            }

            Console.ReadKey();
        }
    }
}
