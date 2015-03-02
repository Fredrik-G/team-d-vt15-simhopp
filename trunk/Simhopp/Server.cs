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
    
    class Server
    {
        #region Data
        TcpClient clientSocket;
        TcpListener serverSocket;
        int counter;
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for creating a new server, accessable on the port 9059
        /// </summary>
        public Server()
        {
            counter = 0;
            serverSocket = new TcpListener(IPAddress.Any, 9059);
            clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" >> Server Started");
            Thread listenerLoop = new Thread(ListenerLoop);
            listenerLoop.Start();
            listenerLoop.IsBackground = true;
        }
        #endregion

        #region Member Functions
        /// <summary>
        /// Function for listening for connections and accepting them.
        /// </summary>
        private void ListenerLoop()
        {
            while(true)
            {
                counter++;
                clientSocket = serverSocket.AcceptTcpClient();
                HandleClient handleClient = new HandleClient();
                handleClient.StartClient(clientSocket);
                Console.WriteLine(" >> Client " + counter + " connected!");
                SendDataToClient();
            }
        }
        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        public void SendDataToClient()
        {
            ServerObjectData message = new ServerObjectData("Contest", "Name", "Trick", 9.5);//Should get data from testboxes
            NetworkStream networkStream = clientSocket.GetStream();
            string serializedString;
            ASCIIEncoding asciiEncoder = new ASCIIEncoding();
            using(MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(ServerObjectData));
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
            string stringIp = string.Empty;
            stringIp = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(stringIp);
            IPAddress[] ipForThis = ipEntry.AddressList;
            return ipForThis[1];
        }
        #endregion
    }
}
