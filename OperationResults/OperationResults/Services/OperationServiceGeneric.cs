using OperationResults.Generic;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<Task<TResult>> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var operationParam = AsyncParamsFactory.CreateSimpleWithResult(operation);
		return await DoOperationWithResultAsync(operationParam, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		ISimpleOperationAsyncParam<TResult> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = await operation.InvokeAsync();
			result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result, log);
		}
		return result;
	}
	
	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
		Func<IOperationResult<TResult>, Task<TResult>> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationWithResultAsync(operationParam, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationWithResultAsync<TResult>(
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

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Func<TResult> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var operationParam = ParamsFactory.CreateSimpleWithResult(operation);
		return DoOperationWithResult(operationParam, log);
	}

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		ISimpleOperationParam<TResult> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			var operationResult = operation.Invoke(); 
			result.Done(operationResult);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result, log);
		}
		return result;
	}
	
	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
		Action<IOperationResult<TResult>> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		return DoOperationWithResult(operationParam, log);
	}

	public static IOperationResult<TResult> DoOperationWithResult<TResult>(
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
