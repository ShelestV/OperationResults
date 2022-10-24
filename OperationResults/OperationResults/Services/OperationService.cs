using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult> DoOperationAsync(
		Func<Task> operation)
	{
		var operationParam = AsyncParamsFactory.Create(operation);
		return await DoOperationAsync(operationParam);
	}
	
	public static async Task<IOperationResult> DoOperationAsync(
		DoOperationAsync operation,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.Create(operation, finishOperation);
		return await DoOperationAsync(operationParam);
	}

	public static async Task<IOperationResult> DoOperationAsync(
		OperationAsyncParam operation)
	{
		var result = OperationResultFactory.Create();
        try
        {
            await operation.InvokeAsync(result);
            if (operation.FinishOperation)
	            result.Done();
        }
        catch (Exception ex) 
        {
            FailOperation(ex, result);
        }
		return result;
	}

	public static async Task<IOperationResult> DoOperationAsync(
		Func<Task> operation,
		ILogOperationWithSuffixParam log)
	{
		var operationParam = AsyncParamsFactory.Create(operation);
		return await DoOperationAsync(operationParam, log);
	}
	
    public static async Task<IOperationResult> DoOperationAsync(
        DoOperationAsync operation,
        ILogOperationWithSuffixParam log,
        bool finishOperation = true)
    {
        var operationParam = AsyncParamsFactory.Create(operation, finishOperation);
        return await DoOperationAsync(operationParam, log);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        OperationAsyncParam operation,
        ILogOperationWithSuffixParam log)
    {
        var result = OperationResultFactory.Create();
        try
        {
            await operation.InvokeAsync(result);
            if (operation.FinishOperation)
	            result.Done();
        }
        catch (Exception ex)
        {
            FailOperation(ex, result, log);
        }
        return result;
    }

    public static IOperationResult DoOperation(
	    Action operation)
    {
	    var operationParam = ParamsFactory.Create(operation);
	    return DoOperation(operationParam);
    }
    
	public static IOperationResult DoOperation(
	    DoOperation operation,
	    bool finishOperation = true)
	{
		var operationParam = ParamsFactory.Create(operation, finishOperation);
		return DoOperation(operationParam);
	}

	public static IOperationResult DoOperation(
		OperationParam operation)
	{
		var result = OperationResultFactory.Create();
		try
		{
			operation.Invoke(result);
			if (operation.FinishOperation)
				result.Done();
		}
		catch (Exception ex)
		{
			FailOperation(ex, result);
		}
		return result;
	}

	public static IOperationResult DoOperation(
		Action operation,
		ILogOperationWithSuffixParam log)
	{
		var param = ParamsFactory.Create(operation);
		return DoOperation(param, log);
	}
	
	public static IOperationResult DoOperation(
		DoOperation operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var param = ParamsFactory.Create(operation, finishOperation);
		return DoOperation(param, log);
	}

	public static IOperationResult DoOperation(
		OperationParam operation,
		ILogOperationWithSuffixParam log)
    {
        var result = OperationResultFactory.Create();
        try
        {
            operation.Invoke(result);
            if (operation.FinishOperation)
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