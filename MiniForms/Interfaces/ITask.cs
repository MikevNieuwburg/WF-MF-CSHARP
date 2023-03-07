using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Interfaces
{
    public interface ITask
    {
        public void Execute();
        public Type TaskType { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
