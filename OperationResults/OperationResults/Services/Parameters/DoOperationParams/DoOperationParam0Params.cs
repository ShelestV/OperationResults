using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam : OperationParam
{
    private readonly DoOperation operation;

    public DoOperationParam(DoOperation operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result);
    }
}