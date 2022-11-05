using OperationResults.Generic;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncParam<TResult> : IOperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, Task> operation;

    internal DoOperationAsyncParam(
        Func<IOperationResult<TResult>, Task> operation)
    {
        this.operation = operation;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1> : IOperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, Task> operation;
    private readonly T1 value1;
    
    internal DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, Task> operation,
        T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1, T2> : IOperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    internal DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, T2, Task> operation,
        T1 value1,
        T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1, T2, T3> : IOperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, T3, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    
    internal DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, T2, T3, Task> operation,
        T1 value1,
        T2 value2,
        T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
