using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncWithResultAutoCompletionParam<TResult> : OperationAsyncParam<TResult>
{
    private readonly Func<Task<TResult>> operation;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<Task<TResult>> operation)
    {
        this.operation = operation;
    }
    
    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke();
    }
}

public sealed class DoOperationAsyncWithResultAutoCompletionParam<TResult, T1> : OperationAsyncParam<TResult>
{
    private readonly Func<T1, Task<TResult>> operation;
    private readonly T1 value1;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, Task<TResult>> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1);
    }
}

public sealed class DoOperationAsyncWithResultAutoCompletionParam<TResult, T1, T2> : OperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, Task<TResult>> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, T2, Task<TResult>> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }
    
    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(value1, value2);
    }
}

public sealed class DoOperationAsyncWithResultAutoCompletionParam<TResult, T1, T2, T3> : OperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, T3, Task<TResult>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, T2, T3, Task<TResult>> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}
