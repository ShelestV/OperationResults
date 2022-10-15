﻿namespace OperationResults.Services.Delegates
{
    public delegate Task DoOperationAsync(IOperationResult result);
    public delegate Task DoOperationAsync<in T1>(IOperationResult result, T1 value1);
    public delegate Task DoOperationAsync<in T1, in T2>(IOperationResult result, T1 value1, T2 value2);
    public delegate Task DoOperationAsync<in T1, in T2, in T3>(IOperationResult result, T1 value1, T2 value2, T3 value3);
}

namespace OperationResults.Services.Delegates.Generic
{
    using OperationResults.Generic;

    public delegate Task<TResult> DoOperationAsync<TResult>(IOperationResult<TResult> result);
    public delegate Task<TResult> DoOperationAsync<TResult, in T1>(IOperationResult<TResult> result, T1 value1);
    public delegate Task<TResult> DoOperationAsync<TResult, in T1, in T2>(IOperationResult<TResult> result, T1 value1, T2 value2);
    public delegate Task<TResult> DoOperationAsync<TResult, in T1, in T2, in T3>(IOperationResult<TResult> result, T1 value1, T2 value2, T3 value3);
}