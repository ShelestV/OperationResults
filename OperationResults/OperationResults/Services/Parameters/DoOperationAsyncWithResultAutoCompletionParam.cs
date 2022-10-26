using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public class DoOperationAsyncWithResultAutoCompletionParam : OperationAsyncParam
{
    private readonly Func<Task> operation;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<Task> operation)
    {
        this.operation = operation;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke();
    }
}

public sealed class DoOperationAsyncWithResultAutoCompletionParam<T1> : OperationAsyncParam
{
    private readonly Func<T1, Task> operation;
    private readonly T1 value1;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, Task> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke(value1);
    }
}

public sealed class DoOperationAsyncWithResultAutoCompletionParam<T1, T2> : OperationAsyncParam
{
    private readonly Func<T1, T2, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, T2, Task> operation, T1 value1, T2 value2)
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

public sealed class DoOperationAsyncWithResultAutoCompletionParam<T1, T2, T3> : OperationAsyncParam
{
    private readonly Func<T1, T2, T3, Task> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationAsyncWithResultAutoCompletionParam(Func<T1, T2, T3, Task> operation, T1 value1, T2 value2, T3 value3)
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
