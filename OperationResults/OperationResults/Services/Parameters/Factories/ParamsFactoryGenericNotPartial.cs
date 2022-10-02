using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory<TResult>
{
	public static IOperationParam<TResult> Create(DoOperation<TResult> operation)
	{
		return new Generic.DoOperationParam<TResult>(operation);
	}

	public static IOperationParam<TResult> Create<T1>(DoOperation<TResult, T1> operation, T1 value1)
	{
		return new Generic.DoOperationParam<TResult, T1>(operation, value1);
	}

	public static IOperationParam<TResult> Create<T1, T2>(DoOperation<TResult, T1, T2> operation, T1 value1, T2 value2)
	{
		return new Generic.DoOperationParam<TResult, T1, T2>(operation, value1, value2);
	}

	public static IOperationParam<TResult> Create<T1, T2, T3>(DoOperation<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
	{
		return new Generic.DoOperationParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
	}

}
