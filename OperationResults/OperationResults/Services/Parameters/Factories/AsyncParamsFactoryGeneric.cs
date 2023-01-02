using OperationResults.Generic;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public static partial class AsyncParamsFactory
{
	public static IOperationAsyncParam<TResult> CreateWithResult<TResult>(
		Func<IOperationResult<TResult>, Task> operation)
	{
		return new Generic.AsyncParam<TResult>(operation);
	}

	public static IOperationAsyncParam<TResult> CreateWithResult<TResult, T1>(
		Func<IOperationResult<TResult>, T1, Task> operation,
		T1 value1)
	{
		return new Generic.AsyncParam<TResult, T1>(operation, value1);
	}

	public static IOperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2>(
		Func<IOperationResult<TResult>, T1, T2, Task> operation,
		T1 value1,
		T2 value2)
	{
		return new Generic.AsyncParam<TResult, T1, T2>(operation, value1, value2);
	}

	public static IOperationAsyncParam<TResult> CreateWithResult<TResult, T1, T2, T3>(
		Func<IOperationResult<TResult>, T1, T2, T3, Task> operation,
		T1 value1, 
		T2 value2,
		T3 value3)
	{
		return new Generic.AsyncParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
	}

	public static ISimpleOperationAsyncParam<TResult> CreateSimpleWithResult<TResult>(
		Func<Task<TResult?>> operation,
		bool shouldThrowNullException = false)
	{
		return new Generic.SimpleAsyncParam<TResult>(operation, shouldThrowNullException);
	}

	public static ISimpleOperationAsyncParam<TResult> CreateSimpleWithResult<TResult, T1>(
		Func<T1, Task<TResult?>> operation,
		T1 value1,
		bool shouldThrowNullException = false)
	{
		return new Generic.SimpleAsyncParam<TResult, T1>(operation, value1, shouldThrowNullException);
	}

	public static ISimpleOperationAsyncParam<TResult> CreateSimpleWithResult<TResult, T1, T2>(
		Func<T1, T2, Task<TResult?>> operation,
		T1 value1,
		T2 value2,
		bool shouldThrowNullException = false)
	{
		return new Generic.SimpleAsyncParam<TResult, T1, T2>(operation, value1, value2, shouldThrowNullException);
	}

	public static ISimpleOperationAsyncParam<TResult> CreateSimpleWithResult<TResult, T1, T2, T3>(
		Func<T1, T2, T3, Task<TResult?>> operation, 
		T1 value1,
		T2 value2,
		T3 value3,
		bool shouldThrowNullException = false)
	{
		return new Generic.SimpleAsyncParam<TResult, T1, T2, T3>(operation, value1, value2, value3, shouldThrowNullException);
	}
}
