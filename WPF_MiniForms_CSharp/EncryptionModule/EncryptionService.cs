using System;
using System.Diagnostics;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Models.Functions;

public class EncryptionService : IService
{
    private Encryption _encryption;

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

    public EncryptionService(Encryption encryptionPage)
    {
        _encryption = encryptionPage;
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

    public void GetCryptoObject()
    {
        _encryption.Show();
        _encryption.Closing += _encryption_Closing;
    }

    private void _encryption_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        TaskResult = _encryption.GetEncryptionObject;
    }

    public void Execute() { EncodeFile(); }

}
