using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.LogDelegates;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
	DoOperationAsync<TResult> operation,
	ILogOperationWithSuffixParam? log = null)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return await DoOperationAsync(param, log);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		IOperationAsyncParam<TResult> operation,
		Log<string>? log = null)
	{
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return await DoOperationAsync(operation, logParam);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
		DoOperationAsync<TResult> operation,
		Log<string>? log = null)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return await DoOperationAsync(operationParam, logParam);
	}

	public static async Task<IOperationResult<TResult>> DoOperationAsync<TResult>(
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

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		ILogOperationWithSuffixParam? log = null)
	{
		var param = ParamsFactory.CreateWithResult(operation);
		return DoOperation(param, log);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		IOperationParam<TResult> operation,
		Log<string>? log = null)
	{
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return DoOperation(operation, logParam);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
		DoOperation<TResult> operation,
		Log<string>? log = null)
	{
		var operationParam = ParamsFactory.CreateWithResult(operation);
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return DoOperation(operationParam, logParam);
	}

	public static IOperationResult<TResult> DoOperation<TResult>(
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
