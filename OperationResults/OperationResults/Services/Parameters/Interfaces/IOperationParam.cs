namespace OperationResults.Services.Parameters.Interfaces;

public interface IOperationParam
{
    void Invoke(IOperationResult result);
}

public interface IOperationParam<TResult>
{
    void Invoke(OperationResults.Generic.IOperationResult<TResult> result);
}