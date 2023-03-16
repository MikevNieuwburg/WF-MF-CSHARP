using System;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Interfaces
{
    public interface IModule
    {
        
        /// <summary>
        /// This is the execute functionality which will return a boolean whether it has completed successfully or not.
        /// </summary>
        /// <returns></returns>
        public Action Execute();

        /// <summary>
        /// TaskType will return what the type is of the result once Execute has ran to completion. <para><see cref="typeof(record)"/></para>
        /// </summary>
        public object TaskInput { get; set; }

        /// <summary>
        /// TaskResult can be set in the execute this will allow the accessor to get their respective value if needed.
        /// </summary>
        public object? TaskResult { get; set; }

    }
}
