using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Models.Objects;
using WPF_MiniForms_CSharp.Models.Records;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            FolderObject folderObject = new FolderObject()
            {
                Path = inputDirectory,
                SubFolders = Directory.EnumerateDirectories(inputDirectory),
                Files = Directory.EnumerateFiles(inputDirectory)
            };

            if(folderObject.SubFolders.Count() > 0)
            {
                var dictionary = new Dictionary<string, IEnumerable<string>>();
                for (int i = 0; i < folderObject.SubFolders.Count(); i++)
                {
                    var dir = folderObject.SubFolders.ToArray()[i];
                    var contentFromDir = Directory.EnumerateFiles(dir);
                    if(contentFromDir.Count() > 0)
                        dictionary.Add(dir, contentFromDir);
                }
            }

            return new Folder(folderObject.Path, folderObject.Files, folderObject.SubFolders ?? null, folderObject.SubFolderContent ?? null);

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
                    var contentFromDir = function.FolderFiles(dir);
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

        public IEnumerable<string> GetUnderlayingFiles(string inputDirectory) => Directory.EnumerateFiles(inputDirectory);
        public IEnumerable<string> GetUnderlayingFolders(string inputDirectory) => Directory.EnumerateDirectories(inputDirectory);

    }
}
