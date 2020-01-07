using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Swapi_C_Sharp
{
    class Web
    {
        public List<Person> Data { get; set; }
        public object JsonConvert { get; private set; }


        public void test()
        {
            WebClient wc = new WebClient();

            var json = wc.DownloadString("https://swapi.co/api/people/1");
            var jsonData = JObject.Parse(json);

            Console.WriteLine("SWAPI : " + json.ToString());
            Console.WriteLine("SWAPI : " + jsonData.GetValue("name"));
          

        }

    }

}
