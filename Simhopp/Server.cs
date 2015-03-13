using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Simhopp.Model;

namespace Simhopp
{
    /// <summary>
    /// The class that is running the server and handling connections.
    /// </summary>
    public class Server
    {
        #region Data
        private TcpClient clientSocket;
        private TcpListener serverSocket;
        private Queue<ClientObjectData> messageQueue = new Queue<ClientObjectData>();
        private ServerObjectData latestMessage;
        private List<HandleClient> handleClientsList = new List<HandleClient>();
        private BindingList<Judge> judgeList = new BindingList<Judge>();
        private bool isServerStarted;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region constructors
        /// <summary>
        /// Constructor for creating a new server, accessable on the port 9059
        /// </summary>
        public Server()
        {
            this.isServerStarted = false;
        }
        #endregion

        #region Member Functions

        /// <summary>
        /// starts up a new server, that clients will be able to connect to
        /// </summary>
        public void StartServer()
        {
            if (!isServerStarted)
            {
                serverSocket = new TcpListener(IPAddress.Any, 9059);
                clientSocket = default(TcpClient);
                serverSocket.Start();

                var listenerLoop = new Thread(ListenerLoop);
                listenerLoop.Start();
                listenerLoop.IsBackground = true;
                isServerStarted = true;
            }
        }

        /// <summary>
        /// Set judges.
        /// </summary>
        /// <param name="judgeList"></param>
        public void SetJudges(ref BindingList<Judge> judgeList)
        {
            this.judgeList = judgeList;
        }

        /// <summary>
        /// Function for listening for connections and accepting them.
        /// </summary>
        private void ListenerLoop()
        {
            var bytesFrom = new byte[10800];
            string ssn;
            string password;
            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                var dataFromClient = string.Empty;
                var networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                ssn = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                password = dataFromClient.Substring(dataFromClient.IndexOf("$") + 1, dataFromClient.IndexOf("#") - dataFromClient.IndexOf("$") - 1);

                var judge = judgeList.SingleOrDefault(x => x.SSN == ssn);


                if (judge != null && judge.CalculateHashAndReturn(password) == judge.Hash)
                {
                    SendConnectionAnswer("Accepted");
                    var handleClient = new HandleClient(ref messageQueue);
                    handleClientsList.Add(handleClient);
                    handleClient.StartClient(clientSocket);
                    SendDataToNewClient();
                }

                else
                {
                    SendConnectionAnswer("Not Accepted");
                    clientSocket.Close();
                }

            }
        }

        void SendConnectionAnswer(string answer)
        {
            var data = string.Empty;
            var networkstream = clientSocket.GetStream();
            var outStream = Encoding.ASCII.GetBytes(answer + "$");
            networkstream.Write(outStream, 0, outStream.Length);
            networkstream.Flush();
        }

        /// <summary>
        /// Sets current diver information.
        /// </summary>
        /// <param name="contestName"></param>
        /// <param name="diverName"></param>
        /// <param name="trickName"></param>
        /// <param name="trickDifficulty"></param>
        public void SetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty)
        {
            latestMessage = new ServerObjectData(contestName, diverName, trickName, trickDifficulty);
        }

        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        public void SendDataToClient()
        {
            if (latestMessage == null)
            {
                return;
            }

            foreach (var client in handleClientsList)
            {
                var networkStream = client.ClientSocket.GetStream();
                string serializedString;
                var asciiEncoder = new ASCIIEncoding();

                using (var stream = new MemoryStream())
                {
                    var xmlS = new XmlSerializer(typeof(ServerObjectData));
                    xmlS.Serialize(stream, latestMessage);
                    serializedString = Encoding.UTF8.GetString(stream.ToArray());
                }

                var outStream = asciiEncoder.GetBytes(serializedString + "$");
                networkStream.Write(outStream, 0, outStream.Length);
                networkStream.Flush();
            }
        }

        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        private void SendDataToNewClient()
        {
            if (latestMessage == null)
            {
                return;
            }

            var networkStream = clientSocket.GetStream();
            string serializedString;
            var asciiEncoder = new ASCIIEncoding();
            using (var stream = new MemoryStream())
            {
                var xmlS = new XmlSerializer(typeof(ServerObjectData));
                xmlS.Serialize(stream, latestMessage);
                serializedString = Encoding.UTF8.GetString(stream.ToArray());
            }
            var outStream = asciiEncoder.GetBytes(serializedString + "$");
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
        }
        /// <summary>
        /// A functions that return the actual IPAddress for this computer.
        /// </summary>
        /// <returns>ipForThis</returns>
        public string GetIPForServer()
        {
            var stringIp = string.Empty;
            stringIp = Dns.GetHostName();
            var ipEntry = Dns.GetHostEntry(stringIp);
            var ipForThis = ipEntry.AddressList;
            return ipForThis[1].ToString();
        }

        public ClientObjectData GetFirstClientObjectData()
        {
            return messageQueue.Count != 0 ? messageQueue.Dequeue() : null;
        }

        #endregion
    }
}
