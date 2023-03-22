namespace WPF_MiniForms_CSharp.EncryptionModule;

public class EncryptionService : IService
{
    private readonly Base64 _base;
    private readonly FolderFunctions _folder;

    public EncryptionService(Base64 base64, FolderFunctions folderFunctions)
    {
        _base = base64;
        _folder = folderFunctions;
    }

    public object? TaskInput { get; set; }
    public object? TaskResult { get; set; }

    public void Execute()
    {
        if (TaskInput is EncodeRecord crypto)
        {
            if (crypto.Encode)
            {
                EncodeFile();
                return;
            }

            DecodeFile();
        }
    }

    private void EncodeFile()
    {
        var obj = TaskInput as EncodeRecord;

        foreach (var item in _folder.FolderFiles(_folder.GetTemporaryFolder))
        {
            var capture = _base.Encrypt(File.ReadAllText(item) + obj?.Password + obj?.Salt);
            File.WriteAllText(item, capture);
        }
    }

    private void DecodeFile()
    {
        var obj = TaskInput as EncodeRecord;

        foreach (var item in _folder.FolderFiles(_folder.GetTemporaryFolder))
        {
            var capture = _base.Decrypt(File.ReadAllText(item));
            File.WriteAllText(item, capture.Replace(obj?.Password + obj?.Salt, ""));
        }
    }
}