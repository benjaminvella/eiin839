using System;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading;

namespace AuthentifiedAccess
{
    class ServiceAccess
    {
        /* Openweather access */

        public void Weather(string city)
        { 
        // you can use the following keys to acces the web service
                String key1 = "327f93f0117f1f0009c3a14ee69ff283";

                                // url to request the weather in Avignon
                string url1 = "http://api.openweathermap.org/data/2.5/weather?q=" + city + ",fr&appid=" + key1;

                // create a web  Client
                // A C#/.Net WebClient provides common methods for sending data to and receiving 
                // data from a resource identified by a URL
                WebClient client = new WebClient();
                // download the data
                string data = client.DownloadString(url1);

                Console.WriteLine("connecting openweathermap.org");
                // wait a bit for the server to have the time to send its answer
                Thread.Sleep(300);

                // show information of the data (json) that have been sent
                JObject jso = JObject.Parse(data);
                Console.WriteLine("in "+city+" the visibility is " + jso.SelectToken("visibility")+
                    " meters and the weather is " + jso.SelectToken("weather[0].main"));           

                // the end
                Console.WriteLine("press a key to exit");

                Console.ReadKey();
        }
    }
}
