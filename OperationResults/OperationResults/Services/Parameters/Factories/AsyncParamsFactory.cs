using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public static partial class AsyncParamsFactory
{
	public static IOperationAsyncParam Create(
		Func<IOperationResult, Task> operation)
	{
		return new AsyncParam(operation);
	}

	public static IOperationAsyncParam Create<T1>(
		Func<IOperationResult, T1, Task> operation, 
		T1 value1)
	{
		return new AsyncParam<T1>(operation, value1);
	}

	public static IOperationAsyncParam Create<T1, T2>(
		Func<IOperationResult, T1, T2, Task> operation, 
		T1 value1, 
		T2 value2)
	{
		return new AsyncParam<T1, T2>(operation, value1, value2);
	}

	public static IOperationAsyncParam Create<T1, T2, T3>(
		Func<IOperationResult, T1, T2, T3, Task> operation,
		T1 value1,
		T2 value2,
		T3 value3)
	{
		return new AsyncParam<T1, T2, T3>(operation, value1, value2, value3);
	}

	public static ISimpleOperationAsyncParam CreateSimple(
		Func<Task> operation)
	{
		return new SimpleAsyncParam(operation);
	}

	public static ISimpleOperationAsyncParam CreateSimple<T1>(
		Func<T1, Task> operation,
		T1 value1)
	{
		return new SimpleAsyncParam<T1>(operation, value1);
	}

	public static ISimpleOperationAsyncParam CreateSimple<T1, T2>(
		Func<T1, T2, Task> operation,
		T1 value1,
		T2 value2)
	{
		return new SimpleAsyncParam<T1, T2>(operation, value1, value2);
	}

	public static ISimpleOperationAsyncParam CreateSimple<T1, T2, T3>(
		Func<T1, T2, T3, Task> operation,
		T1 value1,
		T2 value2,
		T3 value3)
	{
		return new SimpleAsyncParam<T1, T2, T3>(operation, value1, value2, value3);
	}
}
