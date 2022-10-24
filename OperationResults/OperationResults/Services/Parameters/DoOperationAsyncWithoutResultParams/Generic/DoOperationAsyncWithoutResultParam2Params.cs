using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncWithoutResultParam<TResult, T1, T2> : OperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, Task<TResult>> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationAsyncWithoutResultParam(Func<T1, T2, Task<TResult>> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }
    
    public override Task<TResult> InvokeAsync(IOperationResult<TResult> result)
    {
        return this.operation.Invoke(value1, value2);
    }
}