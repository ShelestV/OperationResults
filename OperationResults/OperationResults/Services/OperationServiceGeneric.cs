using OperationResults.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
    public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
         IOperationAsyncParam<TResult> operation,
         ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            await operation.InvokeAsync(result);
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }

    public static IOperationResult<TResult> DoOperation<TResult>(
        IOperationParam<TResult> operation, 
        ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            operation.Invoke(result);
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }

    public static void FailOperation<TResult>(
        Exception ex,
        IOperationResult<TResult> result,
        ILogOperationWithSuffixParam? log = null)
    {
        log?.Invoke($". Error: {ex.Message}");
        result.Fail(ex);
    }

    public static void NotFound<TResult>(
        IOperationResult<TResult> result,
        ILogOperationParam? log = null)
    {
        log?.Invoke();
        result.NotFound();
    }
}
