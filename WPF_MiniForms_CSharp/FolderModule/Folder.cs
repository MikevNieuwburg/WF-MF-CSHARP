using System.Collections.Generic;

namespace WPF_MiniForms_CSharp.Models.Records
{
    public record Folder(string DirectoryPath, string TemporaryFolder, IEnumerable<string> FolderContent, IEnumerable<string> SubDirectories, IDictionary<string, IEnumerable<string>> SubFolderContent);

}
