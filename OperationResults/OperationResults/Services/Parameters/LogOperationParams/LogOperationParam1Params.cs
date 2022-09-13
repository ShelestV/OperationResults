using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationParam<T1> : ILogOperationParam
{
    private readonly Log<T1> log;
    private readonly T1 value1;

    public LogOperationParam(Log<T1> log, T1 value1)
    {
        this.log = log;
        this.value1 = value1;
    }

    public void Invoke()
    {
        this.log.Invoke(this.value1);
    }
}
