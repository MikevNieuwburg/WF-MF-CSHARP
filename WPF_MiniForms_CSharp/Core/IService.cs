namespace WPF_MiniForms_CSharp.Models.Interfaces;

public interface IService
{
    public void Execute();
    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }

}
