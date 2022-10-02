using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation)
	{
		var operationParam = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(operationParam);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
         IOperationAsyncParam<TResult> operation)
    {
        var result = OperationResultFactory.Create<TResult>();
        try
        {
            await operation.InvokeAsync(result);
        }
        catch (Exception ex) 
		{
			FailOperation(ex, result);
		}

        return result;
    }

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		ILogOperationWithSuffixParam log)
	{
		var param = AsyncParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(param, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		 IOperationAsyncParam<TResult> operation,
		 ILogOperationWithSuffixParam log)
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

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return DoOperation(param);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		IOperationParam<TResult> operation)
	{
		var result = OperationResultFactory.Create<TResult>();
		try
		{
			operation.Invoke(result);
		}
		catch (Exception ex)
		{
			FailOperation(ex, result);
		}
		return result;
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		ILogOperationWithSuffixParam log)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return DoOperation(param, log);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
        IOperationParam<TResult> operation, 
        ILogOperationWithSuffixParam log)
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
