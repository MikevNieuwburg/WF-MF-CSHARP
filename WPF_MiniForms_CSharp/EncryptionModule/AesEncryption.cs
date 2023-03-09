using System;
using System.IO;
using System.Security.Cryptography;
using WPF_MiniForms_CSharp.EncryptionModule;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    internal class AesEncryption : IEncryption
    {
        internal byte[] Encrypt(string text, byte[] key, byte[] iv)
        {
            ArgumentException.ThrowIfNullOrEmpty(text);

            if (key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            byte[] eData;
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            aes.BlockSize = 128;
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

            using StreamWriter streamWriter = new StreamWriter(memoryStream);

            streamWriter.Write(text);
            streamWriter.Flush();

            eData = memoryStream.ToArray();

            return eData;
        }

        internal string Decrypt(byte[] text, byte[] key, byte[] iv)
        {
            if (text == null || text.Length <= 0)
                throw new ArgumentNullException("text");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            string eData;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;
                aes.BlockSize = 128;
                using (MemoryStream memoryStream = new MemoryStream(text))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            eData = streamReader.ReadToEnd();
                        }
                    }
                }
                return eData;
            }

        }

        byte[] IEncryption.Encode(string text)
        {
            throw new NotImplementedException();
        }

        string IEncryption.Decrypt(byte[] text)
        {
            throw new NotImplementedException();
        }
    }
}
