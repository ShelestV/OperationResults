using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public static partial class ParamsFactory
{
    public static IOperationParam Create(DoOperation operation)
    {
        return new DoOperationParam(operation);
    }

    public static IOperationParam Create<T1>(DoOperation<T1> operation, T1 value1)
    {
        return new DoOperationParam<T1>(operation, value1);
    }

    public static IOperationParam Create<T1, T2>(DoOperation<T1, T2> operation, T1 value1, T2 value2)
    {
        return new DoOperationParam<T1, T2>(operation, value1, value2);
    }

    public static IOperationParam Create<T1, T2, T3>(DoOperation<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        return new DoOperationParam<T1, T2, T3>(operation, value1, value2, value3);
    }
}
