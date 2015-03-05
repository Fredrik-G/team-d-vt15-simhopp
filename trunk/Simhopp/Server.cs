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
using System.Runtime.ExceptionServices;

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
        int counter;
        private Queue<ClientObjectData> messageQueue =new Queue<ClientObjectData>();
        private bool serverNotStarted;
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for creating a new server, accessable on the port 9059
        /// </summary>
        public Server()
        {
            this.counter = 0;
            this.serverNotStarted = true;
        }
        #endregion

        #region Member Functions

        /// <summary>
        /// starts up a new server, that clients will be able to connect to
        /// </summary>
        public void StartServer()
        {
            if (serverNotStarted)
            {
                serverSocket = new TcpListener(IPAddress.Any, 9059);
                clientSocket = default(TcpClient);
                serverSocket.Start();
                //Console.WriteLine(" >> Server Started");
                var listenerLoop = new Thread(ListenerLoop);
                listenerLoop.Start();
                listenerLoop.IsBackground = true;
                serverNotStarted = false;
            }
        }
        /// <summary>
        /// Function for listening for connections and accepting them.
        /// </summary>
        private void ListenerLoop()
        {
            while(true)
            {
                counter++;
                clientSocket = serverSocket.AcceptTcpClient();
                var handleClient = new HandleClient(ref messageQueue);
                handleClient.StartClient(clientSocket);
                //Console.WriteLine(" >> Client " + counter + " connected!");
                SendDataToClient();
            }
        }
        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        public void SendDataToClient()
        {
            var message = new ServerObjectData("Contest", "Name", "Trick", 9.5);//Should get data from testboxes
            var networkStream = clientSocket.GetStream();
            string serializedString;
            var asciiEncoder = new ASCIIEncoding();
            using(var stream = new MemoryStream())
            {
                var xmlS = new XmlSerializer(typeof(ServerObjectData));
                xmlS.Serialize(stream, message);
                serializedString = Encoding.UTF8.GetString(stream.ToArray());
            }
            byte[] outStream = asciiEncoder.GetBytes(serializedString + "$");
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
        }
        /// <summary>
        /// A functions that return the actual IPAddress for this computer.
        /// </summary>
        /// <returns>ipForThis</returns>
        public IPAddress GetIPForServer()
        {
            var stringIp = string.Empty;
            stringIp = Dns.GetHostName();
            var ipEntry = Dns.GetHostEntry(stringIp);
            IPAddress[] ipForThis = ipEntry.AddressList;
            return ipForThis[1];
        }

        public ClientObjectData GetFirstClientObjectData()
        {
            if (messageQueue.Count != 0)
            {
                return messageQueue.Dequeue();
            }
            return null;
        }
        #endregion
    }
}
