using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
    public static async Task<IOperationResult> DoOperationAsync(
        IOperationAsyncParam operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create();
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

    public static IOperationResult DoOperation(
        IOperationParam operation, 
        ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create();
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

    public static void FailOperation(
    Exception ex,
    IOperationResult result,
    ILogOperationWithSuffixParam? log = null)
    {
        log?.Invoke($". Error: {ex.Message}");
        result.Fail(ex);
    }

    public static void NotFound(
        IOperationResult result,
        ILogOperationParam? log = null)
    {
        log?.Invoke();
        result.NotFound();
    }
}