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
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }

        private static string HTTP_ROOT = "..\\..\\..\\www\\pub\\";

        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {
                string path = HTTP_ROOT;
                string str = reader.ReadString();
                string[] requete = str.Split(' ');
                Console.WriteLine(str);
                if (requete[0].Equals("GET")){
                    if (requete.Length > 1)
                    {
                        path += requete[1];
                        if (File.Exists(path))
                        {
                            string str1 = File.ReadAllText(path);
                            writer.Write("http / 1.0 200 OK"); 
                            writer.Write(str1);
                        }
                        else
                        {
                            writer.Write("File not found");
                        }
                    }
                    else
                    {
                        writer.Write("File not found");
                    }
                }
                else
                {
                    writer.Write("Not a request GET");
                }
            }
        }



    }

}