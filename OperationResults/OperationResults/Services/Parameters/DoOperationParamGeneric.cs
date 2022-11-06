using OperationResults.Generic;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult> : IOperationParam<TResult>
{
    private readonly Action<IOperationResult<TResult>> operation;

    internal DoOperationParam(
        Action<IOperationResult<TResult>> operation)
    {
        this.operation = operation;
    }

    public void Invoke(IOperationResult<TResult> result)
    {
        this.operation.Invoke(result);
    }
}

public sealed class DoOperationParam<TResult, T1> : IOperationParam<TResult>
{
    private readonly Action<IOperationResult<TResult>, T1> operation;
    private readonly T1 value1;

    internal DoOperationParam(
        Action<IOperationResult<TResult>, T1> operation, 
        T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public void Invoke(IOperationResult<TResult> result)
    {
        this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationParam<TResult, T1, T2> : IOperationParam<TResult>
{
    private readonly Action<IOperationResult<TResult>, T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    internal DoOperationParam(
        Action<IOperationResult<TResult>, T1, T2> operation, 
        T1 value1, 
        T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke(IOperationResult<TResult> result)
    {
        this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationParam<TResult, T1, T2, T3> : IOperationParam<TResult>
{
    private readonly Action<IOperationResult<TResult>, T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    internal DoOperationParam(
        Action<IOperationResult<TResult>, T1, T2, T3> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3) 
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public void Invoke(IOperationResult<TResult> result)
    {
        this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
