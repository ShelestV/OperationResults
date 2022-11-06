using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory
{
    public static IOperationParam Create(
        Action<IOperationResult> operation)
    {
        return new DoOperationParam(operation);
    }

    public static IOperationParam Create<T1>(
        Action<IOperationResult, T1> operation, 
        T1 value1)
    {
        return new DoOperationParam<T1>(operation, value1);
    }

    public static IOperationParam Create<T1, T2>(
        Action<IOperationResult, T1, T2> operation, 
        T1 value1, 
        T2 value2)
    {
        return new DoOperationParam<T1, T2>(operation, value1, value2);
    }

    public static IOperationParam Create<T1, T2, T3>(
        Action<IOperationResult, T1, T2, T3> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3)
    {
        return new DoOperationParam<T1, T2, T3>(operation, value1, value2, value3);
    }

    public static ISimpleOperationParam CreateSimple(
        Action operation)
    {
        return new DoSimpleOperationParam(operation);
    }

    public static ISimpleOperationParam CreateSimple<T1>(
        Action<T1> operation, 
        T1 value1)
    {
        return new DoSimpleOperationParam<T1>(operation, value1);
    }

    public static ISimpleOperationParam CreateSimple<T1, T2>(
        Action<T1, T2> operation, 
        T1 value1, 
        T2 value2)
    {
        return new DoSimpleOperationParam<T1, T2>(operation, value1, value2);
    }

    public static ISimpleOperationParam CreateSimple<T1, T2, T3>(
        Action<T1, T2, T3> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3)
    {
        return new DoSimpleOperationParam<T1, T2, T3>(operation, value1, value2, value3);
    }
}
