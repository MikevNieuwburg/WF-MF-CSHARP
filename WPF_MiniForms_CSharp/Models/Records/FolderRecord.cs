﻿using System.Collections.Generic;
using System.IO;

namespace WPF_MiniForms_CSharp.Models.Records
{
    internal record Folder(string DirectoryPath, IEnumerable<string>? Files, IEnumerable<string>? SubDirectories, IDictionary<string, IEnumerable<string>>? SubFolderContent)
    {

        internal bool FolderExists => Directory.Exists(DirectoryPath);
        internal IEnumerable<string>? FolderContent => Files;
        internal IEnumerable<string>? FolderSubFolders => SubDirectories;
        internal IDictionary<string, IEnumerable<string>>? FolderSubContent => SubFolderContent;
    }

}
