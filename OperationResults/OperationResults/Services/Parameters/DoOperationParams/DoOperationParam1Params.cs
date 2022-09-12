using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam<T1> : IOperationParam
{
    private readonly DoOperation<T1> operation;
    private readonly T1 value1;

    public DoOperationParam(DoOperation<T1> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1);
    }
}
