using System;
using System.Diagnostics;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Models.Functions;

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
        if (TaskInput == null)
            throw new ArgumentNullException(nameof(TaskInput));

        if (TaskInput is CryptoObject encryption)
        {
            switch (encryption.EncryptionType)
            {
                case EncryptionType.Standard:
                    foreach (var file in encryption.Folder.FolderContent)
                    {
                        try
                        {
                            System.IO.File.Encrypt(file);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            throw;
                        }
                        finally
                        {
                            Debug.WriteLine($"{file} encrypted using System.IO.File.Encrypt");
                        }
                    }
                    break;
                case EncryptionType.Aes:
                    Encryption encryptionPage = new Encryption(encryption);
                    encryptionPage.Show();
                    break;
                default:
                    throw new ArgumentNullException("Please select a value before you try to set a value.");
            }
        }
    }

    public Action Execute() => EncodeFile;

}
