using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncParam : OperationAsyncParam
{
    private readonly Func<IOperationResult, Task> operation;
    
    public DoOperationAsyncParam(
        Func<IOperationResult, Task> operation, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result);
    }
}

public sealed class DoOperationAsyncParam<T1> : OperationAsyncParam
{
    private readonly Func<IOperationResult, T1, Task> operation;
    private readonly T1 value1;
    
    public DoOperationAsyncParam(
        Func<IOperationResult, T1, Task> operation, 
        T1 value1, 
        bool finishOperation = true) 
        : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationAsyncParam<T1, T2> : OperationAsyncParam
{
    private readonly Func<IOperationResult, T1, T2, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    public DoOperationAsyncParam(
        Func<IOperationResult, T1, T2, Task> operation,
        T1 value1,
        T2 value2,
        bool finishOperation = true)
        : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationAsyncParam<T1, T2, T3> : OperationAsyncParam
{
    private readonly Func<IOperationResult, T1, T2, T3, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    
    public DoOperationAsyncParam(
        Func<IOperationResult, T1, T2, T3, Task> operation,
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

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}