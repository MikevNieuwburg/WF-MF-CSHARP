using System.Collections.Generic;
using System.IO;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    internal class FolderFunctions
    {
        public Folder GetFolderInformation(string inputDirectory)
        {
            if (Directory.Exists(inputDirectory))
            {
                throw new InvalidDataException("Folder does not exist.");
            }

            IEnumerable<string> directories;
            IEnumerable<string> files;

            directories = Directory.EnumerateDirectories(inputDirectory);
            files = Directory.EnumerateFiles(inputDirectory);

            return new Folder(inputDirectory, files, directories);

        }

        public string GetTemporaryDirectory(bool ShouldCreateIfNotExists = false)
        {
            var TempPath = Path.GetTempPath();
            if (Directory.Exists(TempPath) == false && ShouldCreateIfNotExists)
                Directory.CreateDirectory(TempPath);
            return TempPath;
        }

        public IEnumerable<string> GetUnderlayingFiles(string inputDirectory) => Directory.EnumerateFiles(inputDirectory);
        public IEnumerable<string> GetUnderlayingFolders(string inputDirectory) => Directory.EnumerateDirectories(inputDirectory);

    }
}
