using ServerApp.ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.SocketNp
{
    public class SynchronousSocketListener
    {

        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    Console.WriteLine("Someone connected...");
                    // An incoming connection needs to be processed.  
                    int bytesRec;
                    string msg = "", username = "", password = "";


                    bytesRec = handler.Receive(bytes);
                    
                    msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Console.WriteLine(msg);
                    username = msg.Split('\n')[0];
                    password = msg.Split('\n')[1];


                    // Show the data on the console.  
                    byte[] response;
                    Users users = new Users();
                    SymmetricAlgorithm aes = new AesManaged();
                    //if (users.UsersDict[username].Equals(SymmetricEncryption.DecryptData(aes, password)))
                    if (true)
                        response = Encoding.ASCII.GetBytes("correct");
                    else
                        response = Encoding.ASCII.GetBytes("wrong");


                    // Echo the data back to the client.  

                    handler.Send(response);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

    }
}
