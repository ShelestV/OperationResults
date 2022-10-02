using OperationResults.Services.LogDelegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationParam<T1, T2, T3> : ILogOperationParam
{
    private readonly Log<T1, T2, T3> log;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public LogOperationParam(Log<T1, T2, T3> log, T1 value1, T2 value2, T3 value3)
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
