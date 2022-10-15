using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		bool finishOperation = true)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(operationParam, finishOperation);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
         IOperationAsyncParam<TResult> operation,
         bool finishOperation = true)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            var operationResult = await operation.InvokeAsync(result);
            if (finishOperation)
	            result.Done(operationResult);
        }
        catch (Exception ex) 
		{
			FailOperation(ex, result);
		}

        return result;
    }

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var param = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(param, log, finishOperation);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		 IOperationAsyncParam<TResult> operation,
		 ILogOperationWithSuffixParam log,
		 bool finishOperation = true)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = await operation.InvokeAsync(result);
			if (finishOperation)
				result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result, log);
		}
		return result;
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		bool finishOperation = true)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return DoOperation(param, finishOperation);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		IOperationParam<TResult> operation,
		bool finishOperation = true)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = operation.Invoke(result);
			if (finishOperation)
				result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result);
		}
		return result;
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		ILogOperationWithSuffixParam log,
		bool finishOperation = true)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return DoOperation(param, log, finishOperation);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
        IOperationParam<TResult> operation, 
        ILogOperationWithSuffixParam log,
        bool finishOperation = true)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            var operationResult = operation.Invoke(result);
            if (finishOperation)
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
