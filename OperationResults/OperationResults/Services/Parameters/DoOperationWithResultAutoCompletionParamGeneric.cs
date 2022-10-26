using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationWithResultAutoCompletionParam<TResult> : OperationParam<TResult>
{
    private readonly Func<TResult> operation;

    public DoOperationWithResultAutoCompletionParam(Func<TResult> operation)
    {
        this.operation = operation;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke();
    }
}

public sealed class DoOperationWithResultAutoCompletionParam<TResult, T1> : OperationParam<TResult>
{
    private readonly Func<T1, TResult> operation;
    private readonly T1 value1;
    
    public DoOperationWithResultAutoCompletionParam(Func<T1, TResult> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1);
    }
}

public sealed class DoOperationWithResultAutoCompletionParam<TResult, T1, T2> : OperationParam<TResult>
{
    private readonly Func<T1, T2, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    public DoOperationWithResultAutoCompletionParam(Func<T1, T2, TResult> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1, this.value2);
    }
}

public sealed class DoOperationWithResultAutoCompletionParam<TResult, T1, T2, T3> : OperationParam<TResult>
{
    private readonly Func<T1, T2, T3, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    
    public DoOperationWithResultAutoCompletionParam(Func<T1, T2, T3, TResult> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}
