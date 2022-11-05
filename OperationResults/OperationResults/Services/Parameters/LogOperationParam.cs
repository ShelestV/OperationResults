using OperationResults.Services.Parameters.Abstractions;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationParam : ILogOperationParam
{
    private readonly Action log;
    
    internal LogOperationParam(Action log)
    {
        this.log = log;
    }

    public void Invoke()
    {
        this.log.Invoke();
    }
}

public sealed class LogOperationParam<T1> : ILogOperationParam
{
    private readonly Action<T1> log;
    private readonly T1 value1;

    internal LogOperationParam(Action<T1> log, T1 value1)
    {
        this.log = log;
        this.value1 = value1;
    }

    public void Invoke()
    {
        this.log.Invoke(this.value1);
    }
}

public sealed class LogOperationParam<T1, T2> : ILogOperationParam
{
    private readonly Action<T1, T2> log;
    private readonly T1 value1;
    private readonly T2 value2;

    internal LogOperationParam(Action<T1, T2> log, T1 value1, T2 value2)
    {
        this.log = log;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke()
    {
        this.log.Invoke(this.value1, this.value2);
    }
}

public sealed class LogOperationParam<T1, T2, T3> : ILogOperationParam
{
    private readonly Action<T1, T2, T3> log;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    internal LogOperationParam(Action<T1, T2, T3> log, T1 value1, T2 value2, T3 value3)
    {
        this.log = log;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public void Invoke()
    {
        this.log.Invoke(this.value1, this.value2, this.value3);
    }
}
