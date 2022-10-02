using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class AsyncParamsFactory
{
	public static IOperationAsyncParam Create(DoOperationAsync operation)
	{
		return new DoOperationAsyncParam(operation);
	}

	public static IOperationAsyncParam Create<T1>(DoOperationAsync<T1> operation, T1 value1)
	{
		return new DoOperationAsyncParam<T1>(operation, value1);
	}

	public static IOperationAsyncParam Create<T1, T2>(DoOperationAsync<T1, T2> operation, T1 value1, T2 value2)
	{
		return new DoOperationAsyncParam<T1, T2>(operation, value1, value2);
	}

	public static IOperationAsyncParam Create<T1, T2, T3>(DoOperationAsync<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
	{
		return new DoOperationAsyncParam<T1, T2, T3>(operation, value1, value2, value3);
	}
}
