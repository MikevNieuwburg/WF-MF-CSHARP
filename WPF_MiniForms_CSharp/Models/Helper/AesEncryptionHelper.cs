using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    internal class AesEncryptionHelper : Aes
    {
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[]? rgbIV)
        {
            throw new NotImplementedException();
        }

        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[]? rgbIV)
        {
            throw new NotImplementedException();
        }

        public override void GenerateIV()
        {
            throw new NotImplementedException();
        }

        public override void GenerateKey()
        {
            throw new NotImplementedException();
        }
    }
}
