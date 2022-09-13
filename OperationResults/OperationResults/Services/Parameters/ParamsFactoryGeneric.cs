using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static class ParamsFactory<TResult>
{
    public static IOperationAsyncParam<TResult> CreateParam(DoOperationAsync<TResult> operation)
    {
        return new Generic.DoOperationAsyncParam<TResult>(operation);
    }

    public static IOperationAsyncParam<TResult> CreateParam<T1>(DoOperationAsync<TResult, T1> operation, T1 value1)
    {
        return new Generic.DoOperationAsyncParam<TResult, T1>(operation, value1);
    }

    public static IOperationAsyncParam<TResult> CreateParam<T1, T2>(DoOperationAsync<TResult, T1, T2> operation, T1 value1, T2 value2)
    {
        return new Generic.DoOperationAsyncParam<TResult, T1, T2>(operation, value1, value2);
    }

    public static IOperationAsyncParam<TResult> CreateParam<T1, T2, T3>(DoOperationAsync<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new Generic.DoOperationAsyncParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
    }

    public static IOperationParam<TResult> CreateParam(DoOperation<TResult> operation)
    {
        return new Generic.DoOperationParam<TResult>(operation);
    }

    public static IOperationParam<TResult> CreateParam<T1>(DoOperation<TResult, T1> operation, T1 value1)
    {
        return new Generic.DoOperationParam<TResult, T1>(operation, value1);
    }

    public static IOperationParam<TResult> CreateParam<T1, T2>(DoOperation<TResult, T1, T2> operation, T1 value1, T2 value2)
    {
        return new Generic.DoOperationParam<TResult, T1, T2>(operation, value1, value2);
    }

    public static IOperationParam<TResult> CreateParam<T1, T2, T3>(DoOperation<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new Generic.DoOperationParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
    }
}
