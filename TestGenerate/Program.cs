using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGenerate.Model;

namespace TestGenerate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var db = new dbModel())
            {
                Console.WriteLine("тест");
            }
        }
    }
}
