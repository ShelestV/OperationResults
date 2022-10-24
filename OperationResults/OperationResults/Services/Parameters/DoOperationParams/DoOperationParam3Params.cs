using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam<T1, T2, T3> : OperationParam
{
    private readonly DoOperation<T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationParam(DoOperation<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
