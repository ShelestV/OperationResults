using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoSimpleOperationParam<TResult> : ISimpleOperationParam<TResult>
{
    private readonly Func<TResult> operation;

    internal DoSimpleOperationParam(Func<TResult> operation)
    {
        this.operation = operation;
    }
    
    public TResult Invoke()
    {
        return this.operation.Invoke();
    }
}

public sealed class DoSimpleOperationParam<TResult, T1> : ISimpleOperationParam<TResult>
{
    private readonly Func<T1, TResult> operation;
    private readonly T1 value1;
    
    internal DoSimpleOperationParam(Func<T1, TResult> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }
    
    public TResult Invoke()
    {
        return this.operation.Invoke(this.value1);
    }
}

public sealed class DoSimpleOperationParam<TResult, T1, T2> : ISimpleOperationParam<TResult>
{
    private readonly Func<T1, T2, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    internal DoSimpleOperationParam(Func<T1, T2, TResult> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }
    
    public TResult Invoke()
    {
        return this.operation.Invoke(this.value1, this.value2);
    }
}

public sealed class DoSimpleOperationParam<TResult, T1, T2, T3> : ISimpleOperationParam<TResult>
{
    private readonly Func<T1, T2, T3, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    
    internal DoSimpleOperationParam(Func<T1, T2, T3, TResult> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }
    
    public TResult Invoke()
    {
        return this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}
