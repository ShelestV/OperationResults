using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationWithoutResultParam<TResult, T1, T2> : OperationParam<TResult>
{
    private readonly Func<T1, T2, TResult> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    public DoOperationWithoutResultParam(Func<T1, T2, TResult> operation, T1 value1, T2 value2)
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