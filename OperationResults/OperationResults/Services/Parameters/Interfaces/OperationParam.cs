namespace OperationResults.Services.Parameters.Interfaces;

public abstract class OperationParam
{
    public bool FinishOperation { get; }

    protected OperationParam(bool finishOperation = true)
    {
        this.FinishOperation = finishOperation;
    }
    
    public abstract void Invoke(IOperationResult result);
}

public abstract class OperationParam<TResult>
{
    public bool FinishOperation { get; }

    protected OperationParam(bool finishOperation = true)
    {
        this.FinishOperation = finishOperation;
    }
    
    public abstract TResult Invoke(OperationResults.Generic.IOperationResult<TResult> result);
}