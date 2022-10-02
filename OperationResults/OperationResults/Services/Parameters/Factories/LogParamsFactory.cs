using OperationResults.Services.LogDelegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static class LogParamsFactory
{
	public static ILogOperationParam Create(Log operation)
	{
		return new LogOperationParam(operation);
	}

	public static ILogOperationParam Create<T1>(Log<T1> operation, T1 value1)
	{
		return new LogOperationParam<T1>(operation, value1);
	}

	public static ILogOperationParam Create<T1, T2>(Log<T1, T2> operation, T1 value1, T2 value2)
	{
		return new LogOperationParam<T1, T2>(operation, value1, value2);
	}

	public static ILogOperationParam Create<T1, T2, T3>(Log<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
	{
		return new LogOperationParam<T1, T2, T3>(operation, value1, value2, value3);
	}

	public static ILogOperationWithSuffixParam Create(Log<string> operation)
	{
		return new LogOperationWithSuffixParam(operation);
	}

	public static ILogOperationWithSuffixParam Create<T1>(Log<string, T1> operation, T1 value1)
	{
		return new LogOperationWithSuffixParam<T1>(operation, value1);
	}

	public static ILogOperationWithSuffixParam Create<T1, T2>(Log<string, T1, T2> operation, T1 value1, T2 value2)
	{
		return new LogOperationWithSuffixParam<T1, T2>(operation, value1, value2);
	}

	public static ILogOperationWithSuffixParam Create<T1, T2, T3>(Log<string, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
	{
		return new LogOperationWithSuffixParam<T1, T2, T3>(operation, value1, value2, value3);
	}
}
