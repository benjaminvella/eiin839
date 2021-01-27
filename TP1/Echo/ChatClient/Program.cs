using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Echo
{
    class EchoClient
    {
        static TcpClient clientSocket;
        public static void Write()
        {
            BinaryWriter writer = new BinaryWriter(clientSocket.GetStream());

            while (true)
            {

                string str = Console.ReadLine();
                writer.Write(str);
            }
        }
        public static void Read()
        {
            BinaryReader reader = new BinaryReader(clientSocket.GetStream());

            while (true)
            {
                string str = "response: ";
                str = str + reader.ReadString();
                Console.WriteLine(str);
            }

        }

        static void Main(string[] args)
        {
            clientSocket = new TcpClient("localhost", 5000);
            Thread ctThreadWrite = new Thread(Write);
            Thread ctThreadRead = new Thread(Read);
            ctThreadRead.Start();
            ctThreadWrite.Start();
        }
    }
}