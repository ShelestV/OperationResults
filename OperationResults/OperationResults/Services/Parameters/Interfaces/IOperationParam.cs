namespace OperationResults.Services.Parameters.Interfaces;

public interface IOperationParam
{
    void Invoke(IOperationResult result);
}

public interface IOperationParam<TResult>
{
    TResult Invoke(OperationResults.Generic.IOperationResult<TResult> result);
}