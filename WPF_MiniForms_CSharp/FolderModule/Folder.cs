using System.Collections.Generic;
using System.IO;

namespace WPF_MiniForms_CSharp.Models.Records
{
    public record Folder(string DirectoryPath, IEnumerable<string> FolderContent, IEnumerable<string> SubDirectories, IDictionary<string, IEnumerable<string>> SubFolderContent);

}
