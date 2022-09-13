using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static class ParamsFactory
{
    public static IOperationAsyncParam CreateParam(DoOperationAsync operation)
    {
        return new DoOperationAsyncParam(operation);
    }

    public static IOperationAsyncParam CreateParam<T1>(DoOperationAsync<T1> operation, T1 value1)
    {
        return new DoOperationAsyncParam<T1>(operation, value1);
    }

    public static IOperationAsyncParam CreateParam<T1, T2>(DoOperationAsync<T1, T2> operation, T1 value1, T2 value2)
    {
        return new DoOperationAsyncParam<T1, T2>(operation, value1, value2);
    }

    public static IOperationAsyncParam CreateParam<T1, T2, T3>(DoOperationAsync<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new DoOperationAsyncParam<T1, T2, T3>(operation, value1, value2, value3);
    }

    public static IOperationParam CreateParam(DoOperation operation)
    {
        return new DoOperationParam(operation);
    }

    public static IOperationParam CreateParam<T1>(DoOperation<T1> operation, T1 value1)
    {
        return new DoOperationParam<T1>(operation, value1);
    }

    public static IOperationParam CreateParam<T1, T2>(DoOperation<T1, T2> operation, T1 value1, T2 value2)
    {
        return new DoOperationParam<T1, T2>(operation, value1, value2);
    }

    public static IOperationParam CreateParam<T1, T2, T3>(DoOperation<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new DoOperationParam<T1, T2, T3>(operation, value1, value2, value3);
    }

    public static ILogOperationParam CreateLogParam(Log operation)
    {
        return new LogOperationParam(operation);
    }

    public static ILogOperationParam CreateLogParam<T1>(Log<T1> operation, T1 value1)
    {
        return new LogOperationParam<T1>(operation, value1);
    }

    public static ILogOperationParam CreateLogParam<T1, T2>(Log<T1, T2> operation, T1 value1, T2 value2)
    {
        return new LogOperationParam<T1, T2>(operation, value1, value2);
    }

    public static ILogOperationParam CreateLogParam<T1, T2, T3>(Log<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new LogOperationParam<T1, T2, T3>(operation, value1, value2, value3);
    }

    public static ILogOperationWithSuffixParam CreateLogParam(Log<string> operation)
    {
        return new LogOperationWithSuffixParam(operation);
    }

    public static ILogOperationWithSuffixParam CreateLogParam<T1>(Log<string, T1> operation, T1 value1)
    {
        return new LogOperationWithSuffixParam<T1>(operation, value1);
    }

    public static ILogOperationWithSuffixParam CreateLogParam<T1, T2>(Log<string, T1, T2> operation, T1 value1, T2 value2)
    {
        return new LogOperationWithSuffixParam<T1, T2>(operation, value1, value2);
    }

    public static ILogOperationWithSuffixParam CreateLogParam<T1, T2, T3>(Log<string, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new LogOperationWithSuffixParam<T1, T2, T3>(operation, value1, value2, value3);
    }
}
