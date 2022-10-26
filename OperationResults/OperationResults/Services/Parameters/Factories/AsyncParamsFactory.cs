using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class AsyncParamsFactory
{
	public static OperationAsyncParam Create(
		Func<IOperationResult, Task> operation, 
		bool finishOperation = true)
	{
		return new DoOperationAsyncParam(operation, finishOperation);
	}

	public static OperationAsyncParam Create<T1>(
		Func<IOperationResult, T1, Task> operation, 
		T1 value1, 
		bool finishOperation = true)
	{
		return new DoOperationAsyncParam<T1>(operation, value1, finishOperation);
	}

	public static OperationAsyncParam Create<T1, T2>(
		Func<IOperationResult, T1, T2, Task> operation, 
		T1 value1, 
		T2 value2, 
		bool finishOperation = true)
	{
		return new DoOperationAsyncParam<T1, T2>(operation, value1, value2, finishOperation);
	}

	public static OperationAsyncParam Create<T1, T2, T3>(
		Func<IOperationResult, T1, T2, T3, Task> operation,
		T1 value1,
		T2 value2,
		T3 value3,
		bool finishOperation = true)
	{
		return new DoOperationAsyncParam<T1, T2, T3>(operation, value1, value2, value3, finishOperation);
	}

	public static OperationAsyncParam Create(
		Func<Task> operation)
	{
		return new DoOperationAsyncWithResultAutoCompletionParam(operation);
	}

	public static OperationAsyncParam Create<T1>(
		Func<T1, Task> operation,
		T1 value1)
	{
		return new DoOperationAsyncWithResultAutoCompletionParam<T1>(operation, value1);
	}

	public static OperationAsyncParam Create<T1, T2>(
		Func<T1, T2, Task> operation,
		T1 value1,
		T2 value2)
	{
		return new DoOperationAsyncWithResultAutoCompletionParam<T1, T2>(operation, value1, value2);
	}

	public static OperationAsyncParam Create<T1, T2, T3>(
		Func<T1, T2, T3, Task> operation,
		T1 value1,
		T2 value2,
		T3 value3)
	{
		return new DoOperationAsyncWithResultAutoCompletionParam<T1, T2, T3>(operation, value1, value2, value3);
	}
}
