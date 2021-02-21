using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace BasicServerHTTPlistener
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }
 
 
            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                
                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url 
                foreach (string str in request.Url.Segments)
                {
                    Console.WriteLine(str);
                }

                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);


                //parse params in url
                Console.WriteLine("param1 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
                Console.WriteLine("param2 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
                Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
                Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));

                //
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "<HTML><BODY>Hello world!</BODY></HTML>";


                //Question 4
                string[] requestQuery = request.Url.Query.Split('&');

                if (requestQuery.Length == 2)
                {
                    if (request.Url.Query.Contains("param1") && request.Url.Query.Contains("param2"))
                    {
                        string param1 = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                        string param2 = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");
                        Type type = typeof(MyMethods);
                        MethodInfo method = type.GetMethod(request.Url.Segments[request.Url.Segments.Length - 1]);
                        MyMethods myMethods = new MyMethods();
                        responseString = (string) method.Invoke(myMethods, new string[2] { param1, param2 });

                        //Question 5
                        ProcessStartInfo start = new ProcessStartInfo();
                        start.FileName = @"D:\travail\SOC\eiin839\TD2\MyMethod\bin\Debug\netcoreapp3.1\MyMethod.exe";
                        start.Arguments = "" + param1 + " " + param2;
                        start.UseShellExecute = false;
                        start.RedirectStandardOutput = true;
                        using (Process process = Process.Start(start))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                responseString += "<BR>" + result;
                            }
                        }
                    }
                }

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();

                Header header = new Header(); 
                header.showHeader(request);
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }

    public class Header
    {
        public void showHeader(HttpListenerRequest request)
        {         
            foreach (var key in request.Headers.AllKeys)
            {
                Console.WriteLine("Header " + key + "");
            }
        }
    }

    public class MyMethods
    {
        public string MyMethod(string param1, string param2)
        {
            return "<HTML><BODY> Question 4 : Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }
    }
}