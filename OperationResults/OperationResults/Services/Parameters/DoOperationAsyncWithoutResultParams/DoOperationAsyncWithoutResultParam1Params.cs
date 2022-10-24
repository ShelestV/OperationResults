using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncWithoutResultParam<T1> : OperationAsyncParam
{
    private readonly Func<T1, Task> operation;
    private readonly T1 value1;

    public DoOperationAsyncWithoutResultParam(Func<T1, Task> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke(value1);
    }
}