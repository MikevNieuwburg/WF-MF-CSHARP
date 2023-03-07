using MiniForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Models
{
    public class FolderOut : ITask
    {
        public Type TaskType => typeof(FolderOut);

        public string Name => nameof(FolderOut);

        public string Description => "";

        public object TaskData => new object {  };

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
