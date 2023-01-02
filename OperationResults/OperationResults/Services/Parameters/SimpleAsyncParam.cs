using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public sealed class SimpleAsyncParam : ISimpleOperationAsyncParam
{
    private readonly Func<Task> operation;

    internal SimpleAsyncParam(Func<Task> operation)
    {
        this.operation = operation;
    }

    public async Task InvokeAsync()
    {
        await this.operation.Invoke();
    }
}

public sealed class SimpleAsyncParam<T1> : ISimpleOperationAsyncParam
{
    private readonly Func<T1, Task> operation;
    private readonly T1 value1;

    internal SimpleAsyncParam(Func<T1, Task> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public async Task InvokeAsync()
    {
        await this.operation.Invoke(value1);
    }
}

public sealed class SimpleAsyncParam<T1, T2> : ISimpleOperationAsyncParam
{
    private readonly Func<T1, T2, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    internal SimpleAsyncParam(Func<T1, T2, Task> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public async Task InvokeAsync()
    {
        await this.operation.Invoke(this.value1, this.value2);
    }
}

public sealed class SimpleAsyncParam<T1, T2, T3> : ISimpleOperationAsyncParam
{
    private readonly Func<T1, T2, T3, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    internal SimpleAsyncParam(Func<T1, T2, T3, Task> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public async Task InvokeAsync()
    {
        await this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}
