using System;
using System.Threading.Tasks;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Modules
{
    internal class FolderModule : IModule 
    {
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
                _ = GetFolder() != "";
            });
        }

        public string GetFolder()
        {
            FolderDialogFunction function = new FolderDialogFunction();
            return function.Folder();
        }
    }
}
