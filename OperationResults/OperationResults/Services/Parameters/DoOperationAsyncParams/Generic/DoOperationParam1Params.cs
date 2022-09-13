using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncParam<TResult, T1> : IOperationAsyncParam<TResult>
{
    private readonly DoOperationAsync<TResult, T1> operation;
    private readonly T1 value1;

    public DoOperationAsyncParam(DoOperationAsync<TResult, T1> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1);
    }
}
