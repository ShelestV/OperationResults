using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory
{
    public static OperationParam<TResult> CreateWithResult<TResult>(DoOperation<TResult> operation, bool finishOperation = true)
    {
        return new Generic.DoOperationParam<TResult>(operation, finishOperation);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1>(DoOperation<TResult, T1> operation, T1 value1, bool finishOperation = true)
    {
        return new Generic.DoOperationParam<TResult, T1>(operation, value1, finishOperation);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1, T2>(DoOperation<TResult, T1, T2> operation, T1 value1, T2 value2, bool finishOperation = true)
    {
        return new Generic.DoOperationParam<TResult, T1, T2>(operation, value1, value2, finishOperation);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1, T2, T3>(DoOperation<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true)
    {
        return new Generic.DoOperationParam<TResult, T1, T2, T3>(operation, value1, value2, value3, finishOperation);
    }

    public static OperationParam<TResult> CreateWithResult<TResult>(Func<TResult> operation)
    {
        return new Generic.DoOperationWithoutResultParam<TResult>(operation);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1>(Func<T1, TResult> operation, T1 value1)
    {
        return new Generic.DoOperationWithoutResultParam<TResult, T1>(operation, value1);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1, T2>(Func<T1, T2, TResult> operation, T1 value1, T2 value2)
    {
        return new Generic.DoOperationWithoutResultParam<TResult, T1, T2>(operation, value1, value2);
    }

    public static OperationParam<TResult> CreateWithResult<TResult, T1, T2, T3>(Func<T1, T2, T3, TResult> operation, T1 value1, T2 value2, T3 value3)
    {
        return new Generic.DoOperationWithoutResultParam<TResult, T1, T2, T3>(operation, value1, value2, value3);
    }
}
