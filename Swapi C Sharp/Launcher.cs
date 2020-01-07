using System;
using System.IO;
using System.Net;
using System.Text;

namespace Swapi_C_Sharp
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Web web = new Web();

            //web.test();
            //web.test3();
            //Console.WriteLine(web.GET("https://swapi.co/api/people/1"));
            web.test5();
          
        }
    }
}
