using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult> : OperationParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, TResult> operation;

    public DoOperationParam(Func<IOperationResult<TResult>, TResult> operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result);
    }
}

public sealed class DoOperationParam<TResult, T1> : OperationParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, TResult> operation;
    private readonly T1 value1;

    public DoOperationParam(Func<IOperationResult<TResult>, T1, TResult> operation, T1 value1, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationParam<TResult, T1, T2> : OperationParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationParam(Func<IOperationResult<TResult>, T1, T2, TResult> operation, T1 value1, T2 value2, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationParam<TResult, T1, T2, T3> : OperationParam<TResult>
{
    private readonly Func<IOperationResult<TResult>, T1, T2, T3, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationParam(Func<IOperationResult<TResult>, T1, T2, T3, TResult> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true) : base(finishOperation) 
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
