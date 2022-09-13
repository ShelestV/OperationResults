using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationWithSuffixParam : ILogOperationWithSuffixParam
{
    private readonly Log<string> log;

    public LogOperationWithSuffixParam(Log<string> log)
    {
        this.log = log;
    }

    public void Invoke(string suffix)
    {
        this.log(suffix);
    }
}
