using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult> : IOperationParam<TResult>
{
    private readonly DoOperation<TResult> operation;

    public DoOperationParam(DoOperation<TResult> operation)
    {
        this.operation = operation;
    }

    public TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result);
    }
}