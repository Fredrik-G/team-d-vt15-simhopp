﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Threading;
using System.IO;

namespace Simhopp
{
    /// <summary>
    /// Class that is able to connect to a server and communicate with it.
    /// </summary>
    public class Client
    {
        TcpClient clientSocket;
        

        /// <summary>
        /// Constructor for a client
        /// </summary>
        public Client()
        {
            clientSocket = new TcpClient();
        }
        /// <summary>
        /// A function that tries to connect to a server via its IP and port
        /// </summary>
        public void ConnectToServer(string serverIpAddress)
        {
            if(!clientSocket.Client.Connected)
            {
                //Should get the server IP from textBox in clientWindow?
                clientSocket.Connect(serverIpAddress, 9059);
                var threadedChat = new Thread(HandleMessages);
                threadedChat.Start();
                threadedChat.IsBackground = true;
            }
        }
        /// <summary>
        /// Serializes the data into XML-code and sends it to the server
        /// </summary>
        public void SendDataToServer()
        {
            var message = new ClientObjectData("222222", 9.5);//Should get data from testboxes
            var networkStream = clientSocket.GetStream();
            string serializedString;
            var asciiEncoder = new ASCIIEncoding();
            using (var stream = new MemoryStream())
            {
                var xmlS = new XmlSerializer(typeof(ClientObjectData));
                xmlS.Serialize(stream, message);
                serializedString = Encoding.UTF8.GetString(stream.ToArray());
            }
            var outStream = asciiEncoder.GetBytes(serializedString + "$");
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
            Thread.Sleep(10);
        }
        /// <summary>
        /// Handles the messages to and from the server.
        /// 
        /// </summary>
        private void HandleMessages()
        {
            var bytesFrom = new byte[10800];
            var message = new ServerObjectData();
            while(clientSocket.Client.Connected)
            {
                try
                {
                    string dataFromServer = string.Empty;
                    var networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromServer = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                    using(TextReader reader = new StringReader(dataFromServer))
                    {
                        var xmlS = new XmlSerializer(typeof(ServerObjectData));
                        message = (ServerObjectData)xmlS.Deserialize(reader);
                    }
                    //Console.WriteLine(" >> From Server: " + message.ContestName + " " + message.DiverName + " " + message.TrickName + " " + message.TrickDiff);
                }
                catch(Exception ex)//Should be better exception for different exceptions
                {
                    Disconnect();
                    Thread.CurrentThread.Abort();
                }
            }
        }

        /// <summary>
        /// Function that disconnects the Client from the server
        /// </summary>
        public void Disconnect()
        {
            if (clientSocket.Client.Connected)
            {
                clientSocket.Client.Disconnect(true);
            }
        }
    }
}
