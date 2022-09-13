﻿using OperationResults.Generic;
using OperationResults.Services.Delegates.Generic;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters.Generic;

public sealed class DoOperationAsyncParam<TResult, T1, T2, T3> : IOperationAsyncParam<TResult>
{
    private readonly DoOperationAsync<TResult, T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationAsyncParam(DoOperationAsync<TResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public async Task InvokeAsync(IOperationResult<TResult> result)
    {
        await this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}