using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory
{
    public static OperationParam Create(DoOperation operation, bool finishOperation = true)
    {
        return new DoOperationParam(operation, finishOperation);
    }

    public static OperationParam Create<T1>(DoOperation<T1> operation, T1 value1, bool finishOperation = true)
    {
        return new DoOperationParam<T1>(operation, value1, finishOperation);
    }

    public static OperationParam Create<T1, T2>(DoOperation<T1, T2> operation, T1 value1, T2 value2, bool finishOperation = true)
    {
        return new DoOperationParam<T1, T2>(operation, value1, value2, finishOperation);
    }

    public static OperationParam Create<T1, T2, T3>(DoOperation<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true)
    {
        return new DoOperationParam<T1, T2, T3>(operation, value1, value2, value3, finishOperation);
    }

    public static OperationParam Create(Action operation)
    {
        return new DoOperationWithoutResultParam(operation);
    }

    public static OperationParam Create<T1>(Action<T1> operation, T1 value1)
    {
        return new DoOperationWithoutResultParam<T1>(operation, value1);
    }

    public static OperationParam Create<T1, T2>(Action<T1, T2> operation, T1 value1, T2 value2)
    {
        return new DoOperationWithoutResultParam<T1, T2>(operation, value1, value2);
    }

    public static OperationParam Create<T1, T2, T3>(Action<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new DoOperationWithoutResultParam<T1, T2, T3>(operation, value1, value2, value3);
    }
}
