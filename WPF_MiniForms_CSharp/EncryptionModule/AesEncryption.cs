using System;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using WPF_MiniForms_CSharp.EncryptionModule;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    public class AesEncryption : IEncryption
    {
        private CryptoObject _crypto;
        public AesEncryption(CryptoObject cryptoObject) 
        { 
            _crypto = cryptoObject;
        }
        public byte[] Encrypt(string text, byte[] key, byte[] iv)
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

        public string Decrypt(byte[] text, byte[] key, byte[] iv)
        {
            if (text == null || text.Length <= 0)
                throw new ArgumentNullException(nameof(text));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            string eData;
            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            aes.BlockSize = 128;

            using MemoryStream memoryStream = new MemoryStream(text);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(cryptoStream);
            eData = streamReader.ReadToEnd();

            return eData;


        }

        public byte[] Encode(string text)
        {
            switch (_crypto.EncryptionType)
            {
                case EncryptionType.Standard:

                    break;
                case EncryptionType.Aes:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public string Decrypt(byte[] text)
        {
            throw new NotImplementedException();
        }
    }
}
