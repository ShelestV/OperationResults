using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationParam<TResult, T1> : IOperationParam<TResult>
{
    private readonly DoOperation<TResult, T1> operation;
    private readonly T1 value1;

    public DoOperationParam(DoOperation<TResult, T1> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public void Invoke(IOperationResult<TResult> result)
    {
        this.operation.Invoke(result, this.value1);
    }
}
