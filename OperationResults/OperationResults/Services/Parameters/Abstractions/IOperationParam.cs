using OperationResults.Generic;

namespace OperationResults.Services.Parameters.Abstractions;

public interface IOperationParam
{
    void Invoke(IOperationResult result);
}

public interface IOperationParam<TResult>
{
    void Invoke(IOperationResult<TResult> result);
}

public interface ISimpleOperationParam
{
    void Invoke();
}

public interface ISimpleOperationParam<out TResult>
{
    TResult? Invoke();
}