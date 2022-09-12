using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam<T1, T2> : IOperationParam
{
    private readonly DoOperation<T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationParam(DoOperation<T1, T2> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2);
    }
}
