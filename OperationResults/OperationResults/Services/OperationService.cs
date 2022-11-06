using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services;

public static partial class OperationService
{
	    public static async Task<IOperationResult> DoOperationAsync(
        Func<Task> operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var operationParam = AsyncParamsFactory.CreateSimple(operation);
        return await DoOperationAsync(operationParam, log);
    }
    
    public static async Task<IOperationResult> DoOperationAsync(
        ISimpleOperationAsyncParam operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create();
        try
        {
            await operation.InvokeAsync();
            result.Done();
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }
    
    public static async Task<IOperationResult> DoOperationAsync(
        Func<IOperationResult, Task> operation,
        ILogOperationWithSuffixParam? log = null,
        bool finishOperation = true)
    {
        var operationParam = AsyncParamsFactory.Create(operation);
        return await DoOperationAsync(operationParam, log, finishOperation);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        IOperationAsyncParam operation,
        ILogOperationWithSuffixParam? log = null,
        bool finishOperation = true)
    {
        var result = OperationResultFactory.Create();
        try
        {
            await operation.InvokeAsync(result);
            if (finishOperation)
                result.Done();
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }
    
    public static IOperationResult DoOperation(
        Action operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var param = ParamsFactory.CreateSimple(operation);
        return DoOperation(param, log);
    }

    public static IOperationResult DoOperation(
        ISimpleOperationParam operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var result = OperationResultFactory.Create();
        try
        {
            operation.Invoke();
            result.Done();
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }
    
    public static IOperationResult DoOperation(
        Action<IOperationResult> operation,
        ILogOperationWithSuffixParam? log = null,
        bool finishOperation = true)
    {
        var param = ParamsFactory.Create(operation);
        return DoOperation(param, log, finishOperation);
    }

    public static IOperationResult DoOperation(
        IOperationParam operation,
        ILogOperationWithSuffixParam? log = null,
        bool finishOperation = true)
    {
        var result = OperationResultFactory.Create();
        try
        {
            operation.Invoke(result);
            if (finishOperation)
                result.Done();
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