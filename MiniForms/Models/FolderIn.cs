using MiniForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniForms.Models
{
    public class FolderIn : ITask
    {
        public Type TaskType => typeof(FolderIn);

        public string Name => nameof(FolderIn);

        public string Description => "placeholder";

        public string Output { get; set; }

        public void Execute()
        {
            using (FolderBrowserDialog fr = new FolderBrowserDialog() 
            { 
                UseDescriptionForTitle = true,
                Description = "Folder picker",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                ShowNewFolderButton = true
            })
            {
                if(fr.ShowDialog() == DialogResult.OK)
                {
                    Output = fr.SelectedPath;
                }
            }
        }
    }
}
