using System;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    public class EncryptionService : IModule
    {
        private FolderFunctions _folderFunctions;
        private readonly IEncryption _encryption;

        public object TaskInput 
        { 
            get; 
            set; 
        }
        public object? TaskResult 
        { 
            get; 
            set; 
        }

        public EncryptionService(IEncryption encryption)
        {
            _folderFunctions = new FolderFunctions();
            _encryption = encryption;
        }

        private void EncodeFile()
        {
            if(TaskInput == null)
                throw new ArgumentNullException(nameof(TaskInput));

            if(TaskInput is CryptoObject encryption)
            {
                var files = encryption.Folder.FolderContent;
                var path = encryption.Folder.DirectoryPath ?? encryption.Folder.TemporaryFolder;
                switch (encryption.EncryptionType)
                {
                    case EncryptionType.Standard:
                        foreach (var file in files) 
                        {

                        }
                        break;
                    case EncryptionType.Aes:
                        Encryption encryptionPage = new Encryption();
                        encryptionPage.ShowDialog();
                        break;
                    default:
                        throw new ArgumentNullException("Please select a value before you try to set a value.");
                }

            }

        }

        public Action Execute()
        {
            return () => 
            {
                EncodeFile();
            };
        }
    }
}
