using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services;

public static partial class OperationService
{
	public static async Task<IOperationResult> DoOperationAsync(
		DoOperationAsync operation)
	{
		var operationParam = AsyncParamsFactory.Create(operation);
		return await DoOperationAsync(operationParam);
	}

	public static async Task<IOperationResult> DoOperationAsync(
		IOperationAsyncParam operation)
	{
		var result = OperationResultFactory.Create();
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

    public static async Task<IOperationResult> DoOperationAsync(
        DoOperationAsync operation,
        ILogOperationWithSuffixParam log)
    {
        var param = AsyncParamsFactory.Create(operation);
        return await DoOperationAsync(param, log);
    }

    public static async Task<IOperationResult> DoOperationAsync(
        IOperationAsyncParam operation,
        ILogOperationWithSuffixParam log)
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
	    DoOperation operation)
	{
		var operationParam = ParamsFactory.Create(operation);
		return DoOperation(operationParam);
	}

	public static IOperationResult DoOperation(
		IOperationParam operation)
	{
		var result = OperationResultFactory.Create();
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

	public static IOperationResult DoOperation(
	DoOperation operation,
	ILogOperationWithSuffixParam log)
	{
		var param = ParamsFactory.Create(operation);
		return DoOperation(param, log);
	}

	public static IOperationResult DoOperation(
        IOperationParam operation, 
        ILogOperationWithSuffixParam log)
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