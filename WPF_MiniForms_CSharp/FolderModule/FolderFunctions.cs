using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    public class FolderFunctions
    {
        public Folder GetFolderInformation(string inputDirectory)
        {
            if (Directory.Exists(inputDirectory) == false)
            {
                throw new InvalidDataException("Folder does not exist.");
            }
            var enumeratedFiles = Directory.EnumerateFiles(inputDirectory);
            var enumeratedFolders = Directory.EnumerateDirectories(inputDirectory);
            var dictionary = new Dictionary<string, IEnumerable<string>>();

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

            return new Folder(inputDirectory, enumeratedFiles, enumeratedFolders, dictionary);

        }


        public Folder GetFolder()
        {
            FolderDialogFunction function = new FolderDialogFunction();

            var path = function.FolderPath();
            var files = function.FolderFiles(path);
            var directories = function.FolderDirectories(path);
            var dictionary = new Dictionary<string, IEnumerable<string>>();

            if (directories?.Count() > 0)
            {
                for (int i = 0; i < directories.Count(); i++)
                {
                    var dir = directories.ToArray()[i];
                    var contentFromDir = function.FolderFiles(dir + '\\');
                    if(contentFromDir != null)
                        dictionary.Add(dir, contentFromDir);

                }
            }
            Folder folder = new Folder(path, files, directories, dictionary);
            return folder;
        }

        public string GetTemporaryDirectory(bool ShouldCreateIfNotExists = false)
        {
            var TempPath = Path.GetTempPath();
            if (Directory.Exists(TempPath) == false && ShouldCreateIfNotExists)
                Directory.CreateDirectory(TempPath);
            return TempPath;
        }
    }
}
