﻿namespace WPF_MiniForms_CSharp.Core;

public interface IService
{
    public object? TaskInput { get; set; }
    public object? TaskResult { get; set; }
    public void Execute();
}