using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncWithoutResultParam<TResult, T1> : OperationAsyncParam<TResult>
{
    private readonly Func<T1, Task<TResult>> operation;
    private readonly T1 value1;

    public DoOperationAsyncWithoutResultParam(Func<T1, Task<TResult>> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(this.value1);
    }
}