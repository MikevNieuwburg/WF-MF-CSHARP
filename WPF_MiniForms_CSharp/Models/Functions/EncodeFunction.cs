using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Models.Helper;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    internal class EncodeFunction
    {
        private FolderFunctions folderFunctions;
        public EncodeFunction()
        {
            folderFunctions = new FolderFunctions();
        }

        private void EncodeFile(string file)
        {
            AesEncryptionHelper aesEncryptionHelper = new AesEncryptionHelper();
        }

        public bool Encode(string inputDirectory, string filter = "")
        {
            var folderInformation = folderFunctions.GetFolderInformation(inputDirectory);
            
            if (folderInformation == null) 
                return false;

            if (folderInformation.FolderExists == false)
                throw new DirectoryNotFoundException(folderInformation.DirectoryPath);


            foreach (var file in folderInformation.Files)
                EncodeFile(file);

            foreach (var subdirectories in folderInformation.SubDirectories)
            {
                var folders = folderFunctions.GetUnderlayingFiles(subdirectories);
                foreach (var file in folders)
                {
                    EncodeFile(file);
                }
            }

            return true;
        }

    }
}
