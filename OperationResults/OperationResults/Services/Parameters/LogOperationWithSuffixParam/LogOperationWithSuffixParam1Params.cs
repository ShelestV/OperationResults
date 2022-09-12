using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationWithSuffixParam<T1> : ILogOperationWithSuffixParam
{
    private readonly Log<string, T1> log;
    private readonly T1 value1;

    public LogOperationWithSuffixParam(Log<string, T1> log, T1 value1)
    {
        this.log = log;
        this.value1 = value1;
    }

    public void Invoke(string suffix)
    {
        this.log.Invoke(suffix, this.value1);
    }
}
