using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.EncryptionModule
{
    public class CryptoObject
    {
        public Folder Folder
        {
            get;
            set;
        }
        
        public EncryptionType EncryptionType
        { 
            get; 
            set; 
        }

        public string OutputFolder
        {
            get;
            set;
        }

        public string Salt
        { 
            get; 
            set; 
        }

    }
}
