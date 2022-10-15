using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult> DoOperationAsync(
		DoOperationAsync operation,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.Create(operation);
		return await DoOperationAsync(operationParam, finishOperation);
	}

	public static async Task<IOperationResult> DoOperationAsync(
		IOperationAsyncParam operation,
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
            FailOperation(ex, result);
        }
		return result;
	}

    public static async Task<IOperationResult> DoOperationAsync(
        DoOperationAsync operation,
        ILogOperationWithSuffixParam log,
        bool finishOperation = true)
    {
        var param = AsyncParamsFactory.Create(operation);
        return await DoOperationAsync(param, log, finishOperation);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        IOperationAsyncParam operation,
        ILogOperationWithSuffixParam log,
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
	    DoOperation operation,
	    bool finishOperation = true)
	{
		var operationParam = ParamsFactory.Create(operation);
		return DoOperation(operationParam, finishOperation);
	}

	public static IOperationResult DoOperation(
		IOperationParam operation,
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
			FailOperation(ex, result);
		}
		return result;
	}

	public static IOperationResult DoOperation(
		DoOperation operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var param = ParamsFactory.Create(operation);
		return DoOperation(param, log, finishOperation);
	}

	public static IOperationResult DoOperation(
		IOperationParam operation,
		ILogOperationWithSuffixParam log,
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