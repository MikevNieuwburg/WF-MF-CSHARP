using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_MiniForms_CSharp.Models.Objects;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    internal class FolderFunctions
    {
        private bool DoesDirectoryExist(string InputDirectory) => Directory.Exists(InputDirectory);

        public FolderObject GetFolderInformation(string InputDirectory)
        {
            if (DoesDirectoryExist(InputDirectory) == false)
                return new FolderObject();

            IEnumerable<string> directories;
            IEnumerable<string> files;

            directories = Directory.EnumerateDirectories(InputDirectory);
            files = Directory.EnumerateFiles(InputDirectory);
            return new FolderObject()
            {
                ChildDirectories = directories,
                ChildFiles = files,
                DoesExist = true
            };

        }

        public IEnumerable<string> GetUnderlayingFiles(string InputDirectory) => (DoesDirectoryExist(InputDirectory) ? Directory.EnumerateFiles(InputDirectory) : new List<string>());
        public IEnumerable<string> GetUnderlayingFolders(string InputDirectory) => (DoesDirectoryExist(InputDirectory) ? Directory.EnumerateDirectories(InputDirectory) : new List<string>());

    }
}
