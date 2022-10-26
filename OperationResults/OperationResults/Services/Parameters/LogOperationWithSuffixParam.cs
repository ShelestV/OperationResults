using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationWithSuffixParam : ILogOperationWithSuffixParam
{
    private readonly Action<string> log;

    public LogOperationWithSuffixParam(Action<string> log)
    {
        this.log = log;
    }

    public void Invoke(string suffix)
    {
        this.log(suffix);
    }
}

public sealed class LogOperationWithSuffixParam<T1> : ILogOperationWithSuffixParam
{
    private readonly Action<string, T1> log;
    private readonly T1 value1;

    public LogOperationWithSuffixParam(Action<string, T1> log, T1 value1)
    {
        this.log = log;
        this.value1 = value1;
    }

    public void Invoke(string suffix)
    {
        this.log.Invoke(suffix, this.value1);
    }
}

public sealed class LogOperationWithSuffixParam<T1, T2> : ILogOperationWithSuffixParam
{
    private readonly Action<string, T1, T2> log;
    private readonly T1 value1;
    private readonly T2 value2;

    public LogOperationWithSuffixParam(Action<string, T1, T2> log, T1 value1, T2 value2)
    {
        this.log = log;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Invoke(string suffix)
    {
        this.log.Invoke(suffix, this.value1, this.value2);
    }
}

public sealed class LogOperationWithSuffixParam<T1, T2, T3> : ILogOperationWithSuffixParam
{
    private readonly Action<string, T1, T2, T3> log;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public LogOperationWithSuffixParam(Action<string, T1, T2, T3> log, T1 value1, T2 value2, T3 value3)
    {
        this.log = log;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public void Invoke(string suffix)
    {
        this.log.Invoke(suffix, this.value1, this.value2, this.value3);
    }
}