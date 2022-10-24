using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationWithoutResultParam<TResult, T1> : OperationParam<TResult>
{
    private readonly Func<T1, TResult> operation;
    private readonly T1 value1;
    
    public DoOperationWithoutResultParam(Func<T1, TResult> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1);
    }
}