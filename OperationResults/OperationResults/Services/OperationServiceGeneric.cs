using OperationResults.Generic;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<Task<TResult>> operation)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationWithResultAsync(operationParam);
	}
	
	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<IOperationResult<TResult>, Task<TResult>> operation,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation, finishOperation);
		return await DoOperationWithResultAsync(operationParam);
	}

	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
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

	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<Task<TResult>> operation,
		ILogOperationWithSuffixParam log)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationWithResultAsync(operationParam, log);
	}
	
	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<IOperationResult<TResult>, Task<TResult>> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation, finishOperation);
		return await DoOperationWithResultAsync(operationParam, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
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

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Func<TResult> operation)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		return DoOperationWithResult(operationParam);
	}
	
	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Func<IOperationResult<TResult>, TResult> operation,
		bool finishOperation = true)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation, finishOperation);
		return DoOperationWithResult(operationParam);
	}

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
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

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Func<TResult> operation,
		ILogOperationWithSuffixParam log)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		return DoOperationWithResult(operationParam, log);
	}
	
	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Func<IOperationResult<TResult>, TResult> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation, finishOperation);
		return DoOperationWithResult(operationParam, log);
	}

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
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
