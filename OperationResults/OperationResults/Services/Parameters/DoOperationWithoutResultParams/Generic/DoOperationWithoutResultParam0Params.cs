using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationWithoutResultParam<TResult> : OperationParam<TResult>
{
    private readonly Func<TResult> operation;

    public DoOperationWithoutResultParam(Func<TResult> operation)
    {
        this.operation = operation;
    }
    
    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke();
    }
}