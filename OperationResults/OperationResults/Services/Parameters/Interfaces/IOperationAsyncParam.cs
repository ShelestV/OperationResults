namespace OperationResults.Services.Parameters.Interfaces;

public interface IOperationAsyncParam
{
    Task InvokeAsync(IOperationResult result);
}

public interface IOperationAsyncParam<TResult>
{
    Task<TResult> InvokeAsync(OperationResults.Generic.IOperationResult<TResult> result);
}