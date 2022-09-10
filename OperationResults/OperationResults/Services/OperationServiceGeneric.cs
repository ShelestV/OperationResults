using OperationResults.Generic;

namespace OperationResults.Services;

public class OperationService<TResult>
{
    public static async Task<IOperationResult<TResult>> DoOperationAsync(
        Func<IOperationResult<TResult>, Task> operation, 
        Action<string>? logError = null)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            await operation(result);
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, logError);
        }
        return result;
    }

    public static IOperationResult<TResult> DoOperation(
        Action<IOperationResult<TResult>> operation, 
        Action<string>? logError = null)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            operation(result);
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, logError);
        }
        return result;
    }

    public static void FailOperation(
        Exception ex, 
        IOperationResult<TResult> result, 
        Action<string>? logError = null)
    {
        logError?.Invoke($". Error: {ex.Message}");
        result.Fail(ex);
    }

    public static void NotFound(
        IOperationResult<TResult> result, 
        Action? logWarning = null)
    {
        logWarning?.Invoke();
        result.NotFound();
    }
}
