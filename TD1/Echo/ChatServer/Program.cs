using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(5000);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        static string HTTP_ROOT = @"C:\Users\ducch\Desktop\Bossage\Tp-SOC\eiin839\TD1\Echo\www\html";
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }



        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {

                string str = reader.ReadString();
                if (str.StartsWith("GET"))
                {
                    Console.WriteLine("Request : " + str);
                    string[] tab = str.Split(" ");
                    string requestPath = tab.FirstOrDefault(input => input.StartsWith('/'));
                    requestPath = string.IsNullOrEmpty(requestPath) ? HTTP_ROOT + "\\index.html" : HTTP_ROOT + requestPath.Replace("/", "\\");
                    string response = "";
                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(requestPath))
                    {
                        response = sr.ReadToEnd();
                    }
                    Console.WriteLine("Response : " + response);
                    writer.Write(response);
                }
            }
        }



    }

}