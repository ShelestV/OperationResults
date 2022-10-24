using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncWithoutResultParam<TResult> : OperationAsyncParam<TResult>
{
    private readonly Func<Task<TResult>> operation;

    public DoOperationAsyncWithoutResultParam(Func<Task<TResult>> operation)
    {
        this.operation = operation;
    }
    
    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke();
    }
}