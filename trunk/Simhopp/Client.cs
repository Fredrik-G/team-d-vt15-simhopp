using System;
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
    class Client
    {
        TcpClient clientSocket;
        bool clientConnected;
        

        /// <summary>
        /// Constructor for a client
        /// </summary>
        public Client()
        {
            clientSocket = new TcpClient();
            clientConnected = false;
        }
        /// <summary>
        /// A function that tries to connect to a server via its IP and port
        /// </summary>
        public void ConnectToServer(string serverIpAddress)
        {
            if(!clientConnected)
            {
                //Should get the server IP from textBox in clientWindow?
                clientSocket.Connect(serverIpAddress, 9059);
                clientConnected = true;
                Thread threadedChat = new Thread(HandleMessages);
                threadedChat.Start();
                threadedChat.IsBackground = true;
            }
        }
        /// <summary>
        /// Serializes the data into XML-code and sends it to the server
        /// </summary>
        public void SendDataToServer()
        {
            ClientObjectData message = new ClientObjectData("Xiao Kines", 9.5);//Should get data from testboxes
            NetworkStream networkStream = clientSocket.GetStream();
            string serializedString;
            ASCIIEncoding asciiEncoder = new ASCIIEncoding();
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(ClientObjectData));
                xmlS.Serialize(stream, message);
                serializedString = Encoding.UTF8.GetString(stream.ToArray());
            }
            byte[] outStream = asciiEncoder.GetBytes(serializedString + "$");
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
        }
        /// <summary>
        /// Handels the messages to and from the server.
        /// 
        /// </summary>
        private void HandleMessages()
        {
             
            byte[] bytesFrom = new byte[10800];
            string dataFromServer = null;
            ServerObjectData message = new ServerObjectData();
            while(clientConnected)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromServer = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                    using(TextReader reader = new StringReader(dataFromServer))
                    {
                        XmlSerializer xmlS = new XmlSerializer(typeof(ServerObjectData));
                        message = (ServerObjectData)xmlS.Deserialize(reader);
                    }
                    Console.WriteLine(" >> From Server: " + message.ContestName + " " + message.DiverName + " " + message.TrickName + " " + message.TrickDiff);
                }
                catch(Exception ex)//Should be better exception for different exceptions
                {
                    Thread.CurrentThread.Abort();
                }
            }
            Thread.CurrentThread.Abort();
            
        }
    }
}
