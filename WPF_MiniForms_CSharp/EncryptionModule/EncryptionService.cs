using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.Models.Helper;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    public class EncryptionService
    {
        private FolderFunctions _folderFunctions;
        private readonly IEncryption _encryption;

        public EncryptionService(IEncryption encryption)
        {
            _folderFunctions = new FolderFunctions();
            _encryption = encryption;
        }

        private void EncodeFile(string file)
        {

        }

        public bool Encode(string inputDirectory, string filter = "")
        {
            Folder folderInformation = _folderFunctions.GetFolderInformation(inputDirectory);

            foreach (var file in folderInformation.FolderContent)
            {
                EncodeFile(file);
            }

            foreach (var subdirectories in folderInformation.SubDirectories)
            {
                var folders = Directory.GetDirectories(subdirectories);
                foreach (var file in folders)
                {
                    EncodeFile(file);
                }
            }

            return true;
        }

    }
}
