using System.Collections.Generic;
using System.IO;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.Models.Helper;

public class FileContentHelper
{
    private readonly FolderFunctions _folderFunctions;

    public FileContentHelper(FolderFunctions folderFunctions)
    {
        _folderFunctions = folderFunctions;
    }

    public IEnumerable<string> GetFileContent(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}