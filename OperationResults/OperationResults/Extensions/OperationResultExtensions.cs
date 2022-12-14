using OperationResults.Generic;
using OperationResults.Exceptions;

namespace OperationResults;

public static class OperationResultExtensions
{
	public static IOperationResult<TResult> ToGeneric<TResult>(
		this IOperationResult operationResult, 
		TResult? result = default)
	{
		var genericOperationResult = OperationResultFactory.Create<TResult>();
		switch (operationResult.State)
		{
			case OperationResultState.NotFound:
				genericOperationResult.NotFound();
				break;
			case OperationResultState.BadFlow:
				genericOperationResult.Fail(operationResult.Exception);
				break;
			case OperationResultState.Ok:
				SetResult(genericOperationResult, result);
				break;
			case OperationResultState.Processing:
				throw new OperationStillProcessingException();
		}
		return genericOperationResult;
	}

	public static IOperationResult ToGeneral<TResult>(
		this IOperationResult<TResult> genericOperationResult)
	{
		var operationResult = OperationResultFactory.Create();
		switch (genericOperationResult.State)
		{
			case OperationResultState.NotFound:
				operationResult.NotFound();
				break;
			case OperationResultState.BadFlow:
				operationResult.Fail(genericOperationResult.Exception);
				break;
			case OperationResultState.Ok:
				operationResult.Done();
				break;
			case OperationResultState.Processing:
				throw new OperationStillProcessingException();
		}
		return operationResult;
	}

	public static IOperationResult<TOutResult> ChangeResultType<TInResult, TOutResult>(
		this IOperationResult<TInResult> inOperationResult, 
		TOutResult? result = default)
	{
		var outOperationResult = OperationResultFactory.Create<TOutResult>();
		switch (inOperationResult.State)
		{
			case OperationResultState.NotFound:
				outOperationResult.NotFound();
				break;
			case OperationResultState.BadFlow:
				outOperationResult.Fail(inOperationResult.Exception);
				break;
			case OperationResultState.Ok:
				SetResult(outOperationResult, result);
				break;
			case OperationResultState.Processing:
				throw new OperationStillProcessingException();
		}
		return outOperationResult;
	}

	private static void SetResult<TResult>(
		IOperationResult<TResult> operationResult, 
		TResult? result)
	{
		if (EqualityComparer<TResult>.Default.Equals(result, default))
			operationResult.Fail(new ArgumentException("Operation result is invalid"));
		else
			operationResult.Done(result!);
	}

	public static bool IsCorrect<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.Ok;
	}

	public static bool IsCorrect(this IOperationResult result)
	{
		return result.State is OperationResultState.Ok;
	}

	public static bool IsNotFound<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.NotFound;
	}
	
	public static bool IsNotFound(this IOperationResult result)
	{
		return result.State is OperationResultState.NotFound;
	}

	public static bool IsFailed<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.BadFlow;
	}
	
	public static bool IsFailed(this IOperationResult result)
	{
		return result.State is OperationResultState.BadFlow;
	}

	public static bool IsStillProcessing<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.Processing;
	}

	public static bool IsStillProcessing(this IOperationResult result)
	{
		return result.State is OperationResultState.Processing;
	}

	public static bool IsCorrectOrNotFound<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.Ok or OperationResultState.NotFound;
	}

	public static bool IsCorrectOrNotFound(this IOperationResult result)
	{
		return result.State is OperationResultState.Ok or OperationResultState.NotFound;
	}

	public static bool IsFailedOrNotFound<TResult>(this IOperationResult<TResult> result)
	{
		return result.State is OperationResultState.BadFlow or OperationResultState.NotFound;
	}

	public static bool IsFailedOrNotFound(this IOperationResult result)
	{
		return result.State is OperationResultState.BadFlow or OperationResultState.NotFound;
	}
}
