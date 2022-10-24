using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class AsyncParamsFactory
{
	public static OperationAsyncParam<TResult> CreateWithResult<TResult>(DoOperationAsync<TResult> operation, bool finishOperation = true)
	{
		return new Generic.DoOperationAsyncParam<TResult>(operation, finishOperation);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1>(DoOperationAsync<TResult, T1> operation, T1 value1, bool finishOperation = true)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1>(operation, value1, finishOperation);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2>(DoOperationAsync<TResult, T1, T2> operation, T1 value1, T2 value2, bool finishOperation = true)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1, T2>(operation, value1, value2, finishOperation);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2, T3>(DoOperationAsync<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1, T2, T3>(operation, value1, value2, value3, finishOperation);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult>(Func<Task<TResult>> operation)
	{
		return new Generic.DoOperationAsyncWithoutResultParam<TResult>(operation);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1>(Func<T1, Task<TResult>> operation, T1 value1)
	{
		return new Generic.DoOperationAsyncWithoutResultParam<TResult, T1>(operation, value1);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2>(Func<T1, T2, Task<TResult>> operation, T1 value1, T2 value2)
	{
		return new Generic.DoOperationAsyncWithoutResultParam<TResult, T1, T2>(operation, value1, value2);
	}

	public static OperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2, T3>(Func<T1, T2, T3, Task<TResult>> operation, T1 value1, T2 value2, T3 value3)
	{
		return new Generic.DoOperationAsyncWithoutResultParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
	}
}
