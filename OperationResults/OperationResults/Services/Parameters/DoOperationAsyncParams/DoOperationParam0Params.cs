using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public class DoOperationAsyncParam : OperationAsyncParam
{
    private readonly DoOperationAsync operation;
    
    public DoOperationAsyncParam(DoOperationAsync operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result);
    }
}