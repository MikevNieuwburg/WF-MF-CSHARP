using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Modules
{
    internal class FolderModule : IModule 
    {

        #region Interface implementation
        public string? TaskName { get => throw new NotImplementedException();}

        public Type? TaskType => typeof(Folder);
        
        public object? TaskResult 
        { 
            get; 
            set; 
        }

        public Task<bool> Execute()
        {
            return (Task<bool>)Task.Run(() => 
            {
            });
        }
        #endregion
        private FolderFunctions FolderFunctions;
        public FolderModule() 
        {
            FolderFunctions = new FolderFunctions();
            
        }

        public Folder GetFolder() => FolderFunctions.GetFolder();

    }
}
