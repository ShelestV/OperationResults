using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public class DoOperationAsyncParam<TResult> : IOperationAsyncParam<TResult>
{
    private readonly DoOperationAsync<TResult> operation;

    public DoOperationAsyncParam(DoOperationAsync<TResult> operation)
    {
        this.operation = operation;
    }

    public async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result);
    }
}