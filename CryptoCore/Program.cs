using System;
using System.IO;
using System.Security.Cryptography;

using static CryptoCore.AES_alg;

namespace CryptoCore
{
    class Program
    {
        public static void Main()
        {
            string original = "Here is some data to encrypt!";

            AES_alg.GenerateAES("newaes.pem");
            byte[] key = GetKey("newaes.pem");

            byte[] enct_text = EncryptStringToBytes_Aes(original, key);
            string roundtrip = DecryptStringFromBytes_Aes(enct_text, key);

            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).
            /*using (Aes myAes = Aes.Create())
            {
                string key_s = System.Text.Encoding.UTF8.GetString(myAes.Key);
                myAes.KeySize = 256;

                myAes.GenerateKey();
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            } */
        }
  
    }
}