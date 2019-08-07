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
            string original = "Some really secure data to encrypt/decrypt!!!!!";

            AES_alg.GenerateAES("newaes.pem");
            byte[] key = GetKey("newaes.pem");

            byte[] enct_text = EncryptStringToBytes_Aes(original, key);
            string roundtrip = DecryptStringFromBytes_Aes(enct_text, key);
            
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);

     
        }
  
    }
}