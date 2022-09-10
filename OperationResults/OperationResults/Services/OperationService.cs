namespace OperationResults.Services;

public static class OperationService
{
    public static async Task<IOperationResult> DoOperationAsync(
        Func<IOperationResult, Task> operation, 
        Action<string>? logError = null)
    {
        var result = OperationResultFactory.Create();
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

    public static IOperationResult DoOperation(
        Action<IOperationResult> operation, 
        Action<string>? logError = null)
    {
        var result = OperationResultFactory.Create();
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
        IOperationResult result, 
        Action<string>? logError = null)
    {
        logError?.Invoke($". Error: {ex.Message}");
        result.Fail(ex);
    }

    public static void NotFound(
        IOperationResult result, 
        Action? logWarning = null)
    {
        logWarning?.Invoke();
        result.NotFound();
    }
}
