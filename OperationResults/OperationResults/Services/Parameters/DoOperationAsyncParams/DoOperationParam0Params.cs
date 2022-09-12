using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public class DoOperationAsyncParam : IOperationAsyncParam
{
    private readonly DoOperationAsync operation;

    public DoOperationAsyncParam(DoOperationAsync operation)
    {
        this.operation = operation;
    }

    public async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result);
    }
}