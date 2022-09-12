using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class LogOperationParam : ILogOperationParam
{
    private readonly Log log;
    
    public LogOperationParam(Log log)
    {
        this.log = log;
    }

    public void Invoke()
    {
        this.log.Invoke();
    }
}
