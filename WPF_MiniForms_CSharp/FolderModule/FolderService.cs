using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Models.Modules
{
    public class FolderService : IService
    {

        private readonly FolderFunctions _functions;

        #region Interface implementation
        public object? TaskResult { get; set; }
        public object TaskInput { get; set; }
        internal ModuleEnum.ModulesEnum Module { get; set; }

        public FolderService(FolderFunctions functions)
        {
            _functions = functions;
        }

        public void Execute()
        {
            string path = "";

            if (TaskInput is string input && string.IsNullOrEmpty(input) == false)
                path = input;

            if (Module == ModuleEnum.ModulesEnum.FolderIn)
            {
                foreach (var item in _functions.FolderFiles(path))
                {
                    try
                    {
                        var filename = item.Split('\\').Last();
                        if (File.Exists(_functions.GetTemporaryFolder + filename))
                            filename = filename.Insert(filename.IndexOf('.') - 1, " Copy");
                        File.Move(item, _functions.GetTemporaryFolder + filename);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                return;
            }
            var tempFolder = _functions.GetTemporaryFolder;


            if (Directory.Exists(path) == false)
                throw new DirectoryNotFoundException(path);

            foreach (var file in _functions.FolderFiles(tempFolder))
            {
                try
                {
                    var filename = file.Split('\\').Last();
                    File.Copy(file, path + filename);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        #endregion
    }
}
