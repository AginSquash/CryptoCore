﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

namespace CryptoCore
{
    class Client
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public static void Send4ever()
        {
            while (true)
            {
                SendTest();
            }
        }

        public static void SendTest()
        {
            //---data to send to the server---
            string textToSend = "test! 2";

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
            client.Close();

        }
    }
}
