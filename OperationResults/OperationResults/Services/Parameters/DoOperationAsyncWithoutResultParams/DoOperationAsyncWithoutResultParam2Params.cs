using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncWithoutResultParam<T1, T2> : OperationAsyncParam
{
    private readonly Func<T1, T2, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationAsyncWithoutResultParam(Func<T1, T2, Task> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke(this.value1, this.value2);
    }
}