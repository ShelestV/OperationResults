using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam : IOperationParam
{
    private readonly DoOperation operation;

    public DoOperationParam(DoOperation operation)
    {
        this.operation = operation;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result);
    }
}