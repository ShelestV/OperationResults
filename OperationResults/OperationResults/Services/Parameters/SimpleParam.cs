using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public sealed class SimpleParam : ISimpleOperationParam
{
    private readonly Action operation;
    
    internal SimpleParam(Action operation)
    {
        this.operation = operation;
    }

    public void Invoke()
    {
        this.operation.Invoke();
    }
}

public sealed class SimpleParam<T1> : ISimpleOperationParam
{
    private readonly Action<T1> operation;
    private readonly T1 value1;
    
    internal SimpleParam(Action<T1> operation, T1 value1)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public void Invoke()
    {
        this.operation.Invoke(this.value1);
    }
}

public sealed class SimpleParam<T1, T2> : ISimpleOperationParam
{
    private readonly Action<T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    internal SimpleParam(Action<T1, T2> operation, T1 value1, T2 value2)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke()
    {
        this.operation.Invoke(this.value1, this.value2);
    }
}

public sealed class SimpleParam<T1, T2, T3> : ISimpleOperationParam
{
    private readonly Action<T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;
    
    internal SimpleParam(Action<T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public void Invoke()
    {
        this.operation.Invoke(this.value1, this.value2, this.value3);
    }
}