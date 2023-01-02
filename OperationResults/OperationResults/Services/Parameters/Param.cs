using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public sealed class Param : IOperationParam
{
    private readonly Action<IOperationResult> operation;

    internal Param(
        Action<IOperationResult> operation)
    {
        this.operation = operation;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result);
    }
}

public sealed class Param<T1> : IOperationParam
{
    private readonly Action<IOperationResult, T1> operation;
    private readonly T1 value1;

    internal Param(
        Action<IOperationResult, T1> operation, 
        T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1);
    }
}

public sealed class Param<T1, T2> : IOperationParam
{
    private readonly Action<IOperationResult, T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    internal Param(
        Action<IOperationResult, T1, T2> operation, 
        T1 value1, 
        T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class Param<T1, T2, T3> : IOperationParam
{
    private readonly Action<IOperationResult, T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    internal Param(
        Action<IOperationResult, T1, T2, T3> operation, 
        T1 value1, 
        T2 value2, 
        T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
