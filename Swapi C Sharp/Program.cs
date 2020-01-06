using System;
using System.IO;
using System.Net;
using System.Text;

namespace Swapi_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("First Commit");
            Console.WriteLine("Test");

            Web web = new Web();
           
            web.testAsync();
          
        }
    }
}
