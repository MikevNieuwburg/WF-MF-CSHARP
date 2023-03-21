using System;
using System.IO;

namespace WPF_MiniForms_CSharp.Core;

public class TemporaryFolder
{
    private readonly string _tempPath = $"{Directory.GetCurrentDirectory()}\\Process\\{Guid.NewGuid()}\\";

    public string GetTemporaryDirectory()
    {
        if (Directory.Exists(_tempPath) == false)
            Directory.CreateDirectory(_tempPath);
        return _tempPath;
    }
}