using OperationResults.Generic;

namespace OperationResults.Services.Parameters.Abstractions;

public interface IOperationAsyncParam
{
    Task InvokeAsync(IOperationResult result);
}

public interface IOperationAsyncParam<TResult>
{
    Task InvokeAsync(IOperationResult<TResult> result);
}

public interface ISimpleOperationAsyncParam
{
    Task InvokeAsync();
}

public interface ISimpleOperationAsyncParam<TResult>
{
    Task<TResult?> InvokeAsync();
}