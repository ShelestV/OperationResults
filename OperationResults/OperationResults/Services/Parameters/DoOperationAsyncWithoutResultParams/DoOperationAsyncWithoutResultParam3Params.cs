using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncWithoutResultParam<T1, T2, T3> : OperationAsyncParam
{
    private readonly Func<T1, T2, T3, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationAsyncWithoutResultParam(Func<T1, T2, T3, Task> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}