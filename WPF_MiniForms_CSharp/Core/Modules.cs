using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Core;

public class Modules
{
    public void StartTask(IService task)
    {
        task.Execute();
    }
}
