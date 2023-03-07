using System;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Interfaces
{
    public interface ITask
    {
        public string? TaskName { get; }
        public Type? TaskType { get; }
        public Task<bool> Execute();

    }
}
