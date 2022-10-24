using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationWithoutResultParam : OperationParam
{
    private readonly Action operation;

    public DoOperationWithoutResultParam(Action operation)
    {
        this.operation = operation;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke();
    }
}