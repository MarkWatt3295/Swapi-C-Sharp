
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Net;

namespace Swapi_C_Sharp

//Install-Package Microsoft.AspNet.WebApi.Client
/*
 * The preceding command adds the following NuGet packages to the project:

Microsoft.AspNet.WebApi.Client
Newtonsoft.Json
 * 
 * */
{
    class Web
    {
        string uri = "https://swapi.co/api/people/1";
        string uri2 = "https://docs.microsoft.com";

        public void test()
        {



            WebClient wc = new WebClient();
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            string json1 = wc.DownloadString(uri);
            var jsonData = JObject.Parse(json1);

            Console.WriteLine($"SWAPI : {json1.ToString()}");
            Console.WriteLine("SWAPI : " + jsonData.GetValue("name"));

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(uri2);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();

            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                // Console.WriteLine(responseFromServer);
            }


            // Close the response.  
            response.Close();


        }



        public void test3()
        {
            JArray array = new JArray();
            array.Add("Manual text");

            array.Add(new DateTime(2000, 5, 23));

            JObject o = new JObject();
            o["MyArray"] = array;


            string json = o.ToString();
            //Console.WriteLine(json);



            JObject obj = new JObject
                {
                     { "Cpu", "Intel" },
                     { "Memory", 32 },
                     {
                         "Drives", new JArray
                            {
                                 "DVD",
                                 "SSD"
                            }
                        }
                };

            Console.WriteLine("CPU is : " + obj.GetValue("Cpu"));
        }


        public string GET(string url)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    WebResponse response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                String errorText;
                    WebResponse errorResponse = ex.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                         errorText = reader.ReadToEnd();
                        // log errorText
                    }
              
                throw ;
                }
            
        }



        public void test5()
        {

            var client = new RestClient("https://swapi.co/api/people/1/");
          

            var request = new RestRequest(Method.GET);  
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
          
            IRestResponse response = client.Execute(request);
            
            Console.WriteLine(response.Content);
            Console.WriteLine(response);
            //Console.WriteLine("Hello World"); 

        }




    }

}
