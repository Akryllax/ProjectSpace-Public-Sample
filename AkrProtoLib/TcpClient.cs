using Google.Protobuf;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AkrProtoLib
{
    public class TcpClient
    {
        protected Socket tcpSocket;
        protected string hostname;
        protected int port;

        protected Thread thread;

        public delegate void OnDataRecieved(string data);
        public OnDataRecieved onDataRecieved;

        public delegate void OnStdout(string data);
        public OnStdout onStdout;

        public void Connect(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;

            thread = new Thread(new ThreadStart(this._connect));
            thread.Start();
        }

        private void _connect()
        {
            // Connect to a Remote server  
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPHostEntry host = Dns.GetHostEntry(hostname);
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            byte[] bytes = new byte[1024];

            try
            {
                tcpSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    tcpSocket.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        tcpSocket.RemoteEndPoint.ToString());

                    if(onStdout != null)
                    {
                        onStdout("Socket connected to " + tcpSocket.RemoteEndPoint.ToString());
                    }

                    // Encode the data string into a byte array.    
                    byte[] msg = new byte[128];

                    BinMessage srvCommand = new BinMessage
                    {
                        Command = "Shitdown",
                        Arguments = {
                            "Please", "Stop", "THIS", "plz Xd"
                        }
                    };

                    using (MemoryStream stream = new MemoryStream())
                    {
                        srvCommand.WriteTo(stream);
                        msg = stream.ToArray();
                    };

                    byte[] eol = Encoding.ASCII.GetBytes("<EOF>");
                    byte[] rv = new byte[msg.Length + eol.Length];
                    System.Buffer.BlockCopy(msg, 0, rv, 0, msg.Length);
                    System.Buffer.BlockCopy(eol, 0, rv, msg.Length, eol.Length);

                    // Send the data through the socket.    
                    int bytesSent = tcpSocket.Send(rv);

                    if (onStdout != null)
                    {
                        onStdout("Sent: " + rv);
                    }

                    // Receive the response from the remote device.    
                    int bytesRec = tcpSocket.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    if (onStdout != null)
                    {
                        onStdout("Echoed test = " + Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    }

                    // Release the socket.    
                    tcpSocket.Shutdown(SocketShutdown.Both);
                    tcpSocket.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    if (onStdout != null)
                    {
                        onStdout("ArgumentNullException : " + ane.ToString());
                    }
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    if (onStdout != null)
                    {
                        onStdout("SocketException : " + se.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    if (onStdout != null)
                    {
                        onStdout("Unexpected exception : " + e.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (onStdout != null)
                {
                    onStdout("Unexpected exception : " + e.ToString());
                }
            }
        }
    }
}
