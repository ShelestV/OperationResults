namespace OperationResults.Services.Delegates
{
    public delegate void DoOperation(IOperationResult result);
    public delegate void DoOperation<T1>(IOperationResult result, T1 value1);
    public delegate void DoOperation<T1, T2>(IOperationResult result, T1 value1, T2 value2);
    public delegate void DoOperation<T1, T2, T3>(IOperationResult result, T1 value1, T2 value2, T3 value3);
}

namespace OperationResults.Services.Delegates.Generic
{
    using OperationResults.Generic;

    public delegate void DoOperation<TResult>(IOperationResult<TResult> result);
    public delegate void DoOperation<TResult, T1>(IOperationResult<TResult> result, T1 value1);
    public delegate void DoOperation<TResult, T1, T2>(IOperationResult<TResult> result, T1 value1, T2 value2);
    public delegate void DoOperation<TResult, T1, T2, T3>(IOperationResult<TResult> result, T1 value1, T2 value2, T3 value3);
}
