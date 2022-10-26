using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public class DoOperationAsyncParam<TResult> : OperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, Task<TResult>> operation;
    
    public DoOperationAsyncParam(
        Func<IOperationResult<TResult>, Task<TResult>> operation, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
    }

    public override async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1> : OperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, Task<TResult>> operation;
    private readonly T1 value1;
    
    public DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, Task<TResult>> operation, 
        T1 value1, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1, T2> : OperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, Task<TResult>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    public DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, T2, Task<TResult>> operation, 
        T1 value1, 
        T2 value2, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationAsyncParam<TResult, T1, T2, T3> : OperationAsyncParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, T3, Task<TResult>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationAsyncParam(
        Func<IOperationResult<TResult>, T1, T2, T3, Task<TResult>> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
