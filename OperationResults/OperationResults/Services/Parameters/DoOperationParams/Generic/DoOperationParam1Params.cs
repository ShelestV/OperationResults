using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult, T1> : OperationParam<TResult>
{
    private readonly DoOperation<TResult, T1> operation;
    private readonly T1 value1;

    public DoOperationParam(DoOperation<TResult, T1> operation, T1 value1, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override TResult Invoke(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(result, this.value1);
    }
}
