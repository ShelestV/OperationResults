using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		Func<Task<TResult>> operation)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(operationParam);
	}
	
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation, finishOperation);
		return await DoOperationAsync(operationParam);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
         OperationAsyncParam<TResult> operation)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            var operationResult = await operation.InvokeAsync(result);
            if (operation.FinishOperation)
	            result.Done(operationResult);
        }
        catch (Exception ex) 
		{
			FailOperation(ex, result);
		}

        return result;
    }

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		Func<Task<TResult>> operation,
		ILogOperationWithSuffixParam log)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(operationParam, log);
	}
	
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation, finishOperation);
		return await DoOperationAsync(operationParam, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		 OperationAsyncParam<TResult> operation,
		 ILogOperationWithSuffixParam log)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = await operation.InvokeAsync(result);
			if (operation.FinishOperation)
				result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result, log);
		}
		return result;
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		Func<TResult> operation)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		return DoOperation(operationParam);
	}
	
	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		bool finishOperation = true)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation, finishOperation);
		return DoOperation(operationParam);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		OperationParam<TResult> operation)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = operation.Invoke(result);
			if (operation.FinishOperation)
				result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result);
		}
		return result;
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		Func<TResult> operation,
		ILogOperationWithSuffixParam log)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		return DoOperation(operationParam, log);
	}
	
	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation, finishOperation);
		return DoOperation(operationParam, log);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
        OperationParam<TResult> operation, 
        ILogOperationWithSuffixParam log)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            var operationResult = operation.Invoke(result);
            if (operation.FinishOperation)
	            result.Done(operationResult);
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
