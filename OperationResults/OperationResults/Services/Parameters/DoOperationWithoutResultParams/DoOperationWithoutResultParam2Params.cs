using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationWithoutResultParam<T1, T2> : OperationParam
{
    private readonly Action<T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationWithoutResultParam(Action<T1, T2> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(this.value1, this.value2);
    }
}