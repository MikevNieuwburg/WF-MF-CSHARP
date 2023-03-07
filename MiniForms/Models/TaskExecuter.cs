
using MiniForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Models
{
    public class TaskExecuter
    {
        public TaskExecuter(ITask task) 
        {
            task.Execute();
        }
    }
}
