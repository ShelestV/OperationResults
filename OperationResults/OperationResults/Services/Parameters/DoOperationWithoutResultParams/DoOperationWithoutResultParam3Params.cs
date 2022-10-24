using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationWithoutResultParam<T1, T2, T3> : OperationParam
{
    private readonly Action<T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationWithoutResultParam(Action<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}