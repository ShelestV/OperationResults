using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoSimpleOperationAsyncParam<TResult> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<Task<TResult?>> operation;

    internal DoSimpleOperationAsyncParam(Func<Task<TResult?>> operation)
    {
        this.operation = operation;
    }
    
    public async Task<TResult?> InvokeAsync()
    {
        return await this.operation.Invoke();
    }
}

public sealed class DoSimpleOperationAsyncParam<TResult, T1> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, Task<TResult?>> operation;
    private readonly T1 value1;

    internal DoSimpleOperationAsyncParam(Func<T1, Task<TResult?>> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public async Task<TResult?> InvokeAsync()
    {
        return await this.operation.Invoke(this.value1);
    }
}

public sealed class DoSimpleOperationAsyncParam<TResult, T1, T2> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, Task<TResult?>> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    internal DoSimpleOperationAsyncParam(Func<T1, T2, Task<TResult?>> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }
    
    public async Task<TResult?> InvokeAsync()
    {
        return await this.operation.Invoke(value1, value2);
    }
}

public sealed class DoSimpleOperationAsyncParam<TResult, T1, T2, T3> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, T3, Task<TResult?>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    internal DoSimpleOperationAsyncParam(Func<T1, T2, T3, Task<TResult?>> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public async Task<TResult?> InvokeAsync()
    {
        return await this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}
