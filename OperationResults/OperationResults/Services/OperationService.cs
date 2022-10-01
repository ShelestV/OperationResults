using OperationResults.Services.Delegates;
using OperationResults.Services.LogDelegates;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
    public static async Task<IOperationResult> DoOperationAsync(
        DoOperationAsync operation,
        ILogOperationWithSuffixParam? log = null)
    {
        var param = ParamsFactory.Create(operation);
        return await DoOperationAsync(param, log);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        IOperationAsyncParam operation,
        Log<string>? log = null)
    {
        var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return await DoOperationAsync(operation, logParam);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        DoOperationAsync operation,
        Log<string>? log = null)
    {
        var operationParam = ParamsFactory.Create(operation);
        var logParam = log is not null ? ParamsFactory.Create(log) : null;
        return await DoOperationAsync(operationParam, logParam);
    }

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
	DoOperation operation,
	ILogOperationWithSuffixParam? log = null)
	{
		var param = ParamsFactory.Create(operation);
		return DoOperation(param, log);
	}

	public static IOperationResult DoOperation(
		IOperationParam operation,
		Log<string>? log = null)
	{
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return DoOperation(operation, logParam);
	}

	public static IOperationResult DoOperation(
		DoOperation operation,
		Log<string>? log = null)
	{
		var operationParam = ParamsFactory.Create(operation);
		var logParam = log is not null ? ParamsFactory.Create(log) : null;
		return DoOperation(operationParam, logParam);
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