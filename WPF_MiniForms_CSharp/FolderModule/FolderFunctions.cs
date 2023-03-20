using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    public class FolderFunctions
    {
        private FolderDialogFunction _dialogFunctions;

        public Folder GetFolderInformation(string inputDirectory)
        {
            if (Directory.Exists(inputDirectory) == false)
            {
                throw new InvalidDataException("Folder does not exist.");
            }
            var enumeratedFiles = Directory.EnumerateFiles(inputDirectory);
            var enumeratedFolders = Directory.EnumerateDirectories(inputDirectory);
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            var tempDirectory = GetTemporaryDirectory();

            if (enumeratedFolders.Any())
            {
                for (int i = 0; i < enumeratedFolders.Count(); i++)
                {
                    var dir = enumeratedFolders.ToArray()[i];
                    var contentFromDir = Directory.EnumerateFiles(dir + '\\');
                    if(contentFromDir.Count() > 0)
                        dictionary.Add(dir, contentFromDir);
                }
            }

            return new Folder(inputDirectory,tempDirectory, enumeratedFiles, enumeratedFolders, dictionary);

        }


        public Folder GetFolder(FolderDialogFunction dialogFunction)
        {
            _dialogFunctions = dialogFunction;

            var path = _dialogFunctions.FolderPath();
            var files = _dialogFunctions.FolderFiles(path);
            var directories = _dialogFunctions.FolderDirectories(path);
            var dictionary = new Dictionary<string, IEnumerable<string>>();
            var tempFolder = GetTemporaryDirectory();

            if (directories?.Count() > 0)
            {
                for (int i = 0; i < directories.Count(); i++)
                {
                    var dir = directories.ToArray()[i];
                    var contentFromDir = _dialogFunctions.FolderFiles(dir + '\\');
                    if(contentFromDir != null)
                        dictionary.Add(dir, contentFromDir);

                }
            }
            return new Folder(path, tempFolder, files, directories, dictionary);
        }

        private string GetTemporaryDirectory()
        {
            var TempPath = $"{Path.GetTempPath()}AdvancedMiniForms\\";
            if (Directory.Exists(TempPath ) == false)
                Directory.CreateDirectory(TempPath);
            return TempPath;
        }
    }
}
