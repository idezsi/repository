using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class SymmetricEncryption
    {

           
           
            public static string EncryptText(SymmetricAlgorithm aesAlgorithm, string text)
            {
                // Create an encryptor from the AES algorithm instance and pass the aes algorithm key and inialiaztion vector to generate a new random sequence each time for the same text  
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(aesAlgorithm.Key));
                // Create a memory stream to save the encrypted data in it  
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            // Write the text in the stream writer   
                            writer.Write(text);
                        }
                    }

                    // Get the result as a byte array from the memory stream   
                    byte[] encryptedDataBuffer = ms.ToArray();
                return System.Text.Encoding.ASCII.GetString(encryptedDataBuffer);
                // Write the data to a file   
                //File.WriteAllBytes(fileName, encryptedDataBuffer);

            }
        }
  

        public static string DecryptData(SymmetricAlgorithm aesAlgorithm, string value)
        {
            // Create a decryptor from the aes algorithm   
            ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);


            byte[] encryptedDataBuffer = Encoding.ASCII.GetBytes(value);

            // Create a memorystream to write the decrypted data in it   
            using (MemoryStream ms = new MemoryStream(encryptedDataBuffer))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        // Reutrn all the data from the streamreader   
                        return reader.ReadLine();
                    }
                }
            }
        }


    }

    


}
