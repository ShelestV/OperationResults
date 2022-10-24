namespace OperationResults.Services.Parameters.Interfaces;

public abstract class OperationAsyncParam
{
    public bool FinishOperation { get; }

    protected OperationAsyncParam(bool finishOperation = true)
    {
        this.FinishOperation = finishOperation;
    }
    
    public abstract Task InvokeAsync(IOperationResult result);
}

public abstract class OperationAsyncParam<TResult>
{
    public bool FinishOperation { get; }

    protected OperationAsyncParam(bool finishOperation = true)
    {
        this.FinishOperation = finishOperation;
    }
    
    public abstract Task<TResult> InvokeAsync(OperationResults.Generic.IOperationResult<TResult> result);
}