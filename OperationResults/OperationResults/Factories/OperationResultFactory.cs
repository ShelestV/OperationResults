using OperationResults.Generic;

namespace OperationResults;

public static class OperationResultFactory
{
	public static IOperationResult Create()
	{
		return new OperationResult();
	}

	public static IOperationResult<TResult> Create<TResult>()
	{
		return new OperationResult<TResult>();
	}
}
