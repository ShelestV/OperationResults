﻿using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory<TResult>
{
	public static IOperationAsyncParam<TResult> Create(DoOperationAsync<TResult> operation)
	{
		return new Generic.DoOperationAsyncParam<TResult>(operation);
	}

	public static IOperationAsyncParam<TResult> Create<T1>(DoOperationAsync<TResult, T1> operation, T1 value1)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1>(operation, value1);
	}

	public static IOperationAsyncParam<TResult> Create<T1, T2>(DoOperationAsync<TResult, T1, T2> operation, T1 value1, T2 value2)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1, T2>(operation, value1, value2);
	}

	public static IOperationAsyncParam<TResult> Create<T1, T2, T3>(DoOperationAsync<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
	{
		return new Generic.DoOperationAsyncParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
	}
}
