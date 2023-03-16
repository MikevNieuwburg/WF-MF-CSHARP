using iText.Kernel.Pdf.Canvas.Wmf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using WPF_MiniForms_CSharp.FolderModule;
using WPF_MiniForms_CSharp.Models.Modules;

namespace WPF_MiniForms_CSharp.Core
{
    public class Modules
    {
        private FolderPicker _picker;
        private FolderService _folderService;

        public FolderPicker GetFolderPicker(FolderPicker picker, FolderService folderService)
        {
            _picker = picker;
            _folderService = folderService;
            _picker.Service = folderService;

            return _picker;
        }


        public void StartTask(Action task)
        {
            task.Invoke();
        }
    }
}
