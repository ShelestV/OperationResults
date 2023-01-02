using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public static class LogParamsFactory
{
	public static ILogOperationParam Create(
		Action operation)
	{
		return new LogParam(operation);
	}

	public static ILogOperationParam Create<T1>(
		Action<T1> operation, 
		T1 value1)
	{
		return new LogParam<T1>(operation, value1);
	}

	public static ILogOperationParam Create<T1, T2>(
		Action<T1, T2> operation, 
		T1 value1, 
		T2 value2)
	{
		return new LogParam<T1, T2>(operation, value1, value2);
	}

	public static ILogOperationParam Create<T1, T2, T3>(
		Action<T1, T2, T3> operation, 
		T1 value1, 
		T2 value2, 
		T3 value3)
	{
		return new LogParam<T1, T2, T3>(operation, value1, value2, value3);
	}

	public static ILogOperationWithSuffixParam Create(
		Action<string> operation)
	{
		return new LogWithSuffixParam(operation);
	}

	public static ILogOperationWithSuffixParam Create<T1>(
		Action<string, T1> operation, 
		T1 value1)
	{
		return new LogWithSuffixParam<T1>(operation, value1);
	}

	public static ILogOperationWithSuffixParam Create<T1, T2>(
		Action<string, T1, T2> operation, 
		T1 value1, 
		T2 value2)
	{
		return new LogWithSuffixParam<T1, T2>(operation, value1, value2);
	}

	public static ILogOperationWithSuffixParam Create<T1, T2, T3>(
		Action<string, T1, T2, T3> operation, 
		T1 value1, 
		T2 value2, 
		T3 value3)
	{
		return new LogWithSuffixParam<T1, T2, T3>(operation, value1, value2, value3);
	}
}
