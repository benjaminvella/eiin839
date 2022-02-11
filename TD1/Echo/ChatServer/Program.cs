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



        private void Echo()
        {

            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);
            string HTTP_ROOT = "../../../www/pub/";

            while (true)
            {
                string str = reader.ReadString();
                bool isFile = false;
                string method = str.Split(' ')[0];
                string URI = str.Split(' ')[1];
                if(method == "GET")
                {
                    if (Directory.Exists(HTTP_ROOT))
                    {
                        foreach (string file in Directory.GetFiles(HTTP_ROOT, "*"))
                        {
                            if (HTTP_ROOT + URI == file)
                            {
                                Console.WriteLine(file);
                                string fileContent = "HTTP/1.0 200 OK\n\n";
                                fileContent += File.ReadAllText(file);
                                Console.WriteLine(fileContent);
                                writer.Write(fileContent);
                                isFile = true;
                                break;
                            }
                        }
                    }
                    if (!isFile)
                    {
                        Console.WriteLine(str);
                        writer.Write(str);
                    }
                }
                
            }
        }
    }
}