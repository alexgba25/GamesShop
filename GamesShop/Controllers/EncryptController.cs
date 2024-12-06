using GamesShop.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GamesShop.Controllers
{
    public class EncryptController : IEncryptController
    {
        private static readonly string encryptionKey = "YourKey123456789";

        // Método para encriptar
        public string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);


            if (keyBytes.Length != 16 && keyBytes.Length != 32)
            {
                throw new ArgumentException("La clave debe tener 16 o 32 caracteres.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;


                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] encryptedBytes = ms.ToArray();


                        byte[] combinedBytes = new byte[iv.Length + encryptedBytes.Length];
                        Array.Copy(iv, 0, combinedBytes, 0, iv.Length);
                        Array.Copy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length);

                        return Convert.ToBase64String(combinedBytes);
                    }
                }
            }
        }

        // Método para desencriptar
        public string Decrypt(string encryptedText)
        {
            byte[] combinedBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);


            if (keyBytes.Length != 16 && keyBytes.Length != 32)
            {
                throw new ArgumentException("La clave debe tener 16 o 32 caracteres.");
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] iv = new byte[16];
                Array.Copy(combinedBytes, 0, iv, 0, iv.Length);
                aes.IV = iv;


                byte[] encryptedBytes = new byte[combinedBytes.Length - iv.Length];
                Array.Copy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
    }
}