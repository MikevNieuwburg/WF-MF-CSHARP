using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.EncryptionModule
{
    public interface IEncryption
    {
        public byte[] Encode(string text);

        public string Decrypt(byte[] text);
    }
}
