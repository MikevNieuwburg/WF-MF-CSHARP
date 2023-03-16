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
    public class FolderService : IModule 
    {

        #region Interface implementation
        
        public object? TaskResult 
        { 
            get; 
            set; 
        }
        public object TaskInput 
        { 
            get; 
            set; 
        }

        public Action Execute() => () => TaskResult = GetFolder();
        #endregion
        private FolderFunctions FolderFunctions;
        public FolderService() 
        {
            FolderFunctions = new FolderFunctions();
            
        }

        public Folder GetFolder() => FolderFunctions.GetFolder();

    }
}
