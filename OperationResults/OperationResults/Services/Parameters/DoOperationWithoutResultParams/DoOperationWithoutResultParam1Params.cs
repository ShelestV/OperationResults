using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationWithoutResultParam<T1> : OperationParam
{
    private readonly Action<T1> operation;
    private readonly T1 value1;

    public DoOperationWithoutResultParam(Action<T1> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(this.value1);
    }
}