using OperationResults.Services.LogDelegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationParam<T1, T2> : ILogOperationParam
{
    private readonly Log<T1, T2> log;
    private readonly T1 value1;
    private readonly T2 value2;

    public LogOperationParam(Log<T1, T2> log, T1 value1, T2 value2)
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
