using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncParam<TResult, T1, T2> : IOperationAsyncParam<TResult>
{
    private readonly DoOperationAsync<TResult, T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationAsyncParam(DoOperationAsync<TResult, T1, T2> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1, this.value2);
    }
}
