using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public class DoOperationAsyncParam<TResult> : OperationAsyncParam<TResult>
{
    private readonly DoOperationAsync<TResult> operation;
    
    public DoOperationAsyncParam(DoOperationAsync<TResult> operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override async Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return await this.operation.Invoke(result);
    }
}