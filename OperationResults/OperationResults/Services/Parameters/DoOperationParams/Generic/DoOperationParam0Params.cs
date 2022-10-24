using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult> : OperationParam<TResult>
{
    private readonly DoOperation<TResult> operation;

    public DoOperationParam(DoOperation<TResult> operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result);
    }
}