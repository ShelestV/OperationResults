using OperationResults.Generic;
using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory
{
    public static IOperationParam<TResult> CreateWithResult<TResult>(
        Action<IOperationResult<TResult>> operation)
    {
        return new Generic.Param<TResult>(operation);
    }

    public static IOperationParam<TResult> CreateWithResult<TResult, T1>(
        Action<IOperationResult<TResult>, T1> operation, 
        T1 value1)
    {
        return new Generic.Param<TResult, T1>(operation, value1);
    }

    public static IOperationParam<TResult> CreateWithResult<TResult, T1, T2>(
        Action<IOperationResult<TResult>, T1, T2> operation, 
        T1 value1, 
        T2 value2)
    {
        return new Generic.Param<TResult, T1, T2>(operation, value1, value2);
    }

    public static IOperationParam<TResult> CreateWithResult<TResult, T1, T2, T3>(
        Action<IOperationResult<TResult>, T1, T2, T3> operation, 
        T1 value1,
        T2 value2, 
        T3 value3)
    {
        return new Generic.Param<TResult, T1, T2, T3>(operation, value1, value2, value3);
    }

    public static ISimpleOperationParam<TResult> CreateSimpleWithResult<TResult>(
        Func<TResult> operation)
    {
        return new Generic.SimpleParam<TResult>(operation);
    }

    public static ISimpleOperationParam<TResult> CreateSimpleWithResult<TResult, T1>(
        Func<T1, TResult> operation,
        T1 value1)
    {
        return new Generic.SimpleParam<TResult, T1>(operation, value1);
    }

    public static ISimpleOperationParam<TResult> CreateSimpleWithResult<TResult, T1, T2>(
        Func<T1, T2, TResult> operation, 
        T1 value1, 
        T2 value2)
    {
        return new Generic.SimpleParam<TResult, T1, T2>(operation, value1, value2);
    }

    public static ISimpleOperationParam<TResult> CreateSimpleWithResult<TResult, T1, T2, T3>(
        Func<T1, T2, T3, TResult> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3)
    {
        return new Generic.SimpleParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
    }
}
