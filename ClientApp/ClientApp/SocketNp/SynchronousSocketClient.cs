using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;


namespace ClientApp.SocketNp
{
    public class SynchronousSocketClient
    {

        public static void StartClient(string Username, string Password)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];
            SymmetricAlgorithm aes = new AesManaged();

           


            string up = Username+'\n' + SymmetricEncryption.EncryptText(aes, Password);
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] message = Encoding.ASCII.GetBytes(up);
                  
             
                    // Send the data through the socket.  
                    int bytesSent = sender.Send(message);
                    Console.WriteLine(bytesSent);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        
    }
}
