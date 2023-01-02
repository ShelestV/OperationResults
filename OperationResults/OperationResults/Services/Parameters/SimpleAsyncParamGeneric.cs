using OperationResults.Exceptions;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters.Generic;

public sealed class SimpleAsyncParam<TResult> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<Task<TResult?>> operation;
    private readonly bool shouldThrowNullException;

    internal SimpleAsyncParam(Func<Task<TResult?>> operation, bool shouldThrowNullException = false)
    {
        this.operation = operation;
        this.shouldThrowNullException = shouldThrowNullException;
    }
    
    public async Task<TResult?> InvokeAsync()
    {
        var result = await this.operation.Invoke();

        if (shouldThrowNullException && result is null)
            throw new NotFoundException();
        
        return result;
    }
}

public sealed class SimpleAsyncParam<TResult, T1> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, Task<TResult?>> operation;
    private readonly T1 value1;
    private readonly bool shouldThrowNullException;

    internal SimpleAsyncParam(Func<T1, Task<TResult?>> operation, T1 value1, bool shouldThrowNullException = false)
    {
        this.operation = operation;
        this.value1 = value1;
        this.shouldThrowNullException = shouldThrowNullException;
    }

    public async Task<TResult?> InvokeAsync()
    {
        var result = await this.operation.Invoke(this.value1);

        if (shouldThrowNullException && result is null)
            throw new NotFoundException();
        
        return result;
    }
}

public sealed class SimpleAsyncParam<TResult, T1, T2> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, Task<TResult?>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly bool shouldThrowNullException;

    internal SimpleAsyncParam(Func<T1, T2, Task<TResult?>> operation, T1 value1, T2 value2, bool shouldThrowNullException = false)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.shouldThrowNullException = shouldThrowNullException;
    }
    
    public async Task<TResult?> InvokeAsync()
    {
        var result = await this.operation.Invoke(value1, value2);

        if (shouldThrowNullException && result is null)
            throw new NotFoundException();

        return result;
    }
}

public sealed class SimpleAsyncParam<TResult, T1, T2, T3> : ISimpleOperationAsyncParam<TResult>
{
    private readonly Func<T1, T2, T3, Task<TResult?>> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    private readonly bool shouldThrowNullException;

    internal SimpleAsyncParam(Func<T1, T2, T3, Task<TResult?>> operation, T1 value1, T2 value2, T3 value3, bool shouldThrowNullException = false)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
        this.shouldThrowNullException = shouldThrowNullException;
    }

    public async Task<TResult?> InvokeAsync()
    {
        var result = await this.operation.Invoke(this.value1, this.value2, this.value3);

        if (shouldThrowNullException && result is null)
            throw new NotFoundException();

        return result;
    }
}
