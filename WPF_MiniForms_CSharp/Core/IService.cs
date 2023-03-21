namespace WPF_MiniForms_CSharp.Models.Interfaces;

public interface IService
{
    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }
    public void Execute();
}