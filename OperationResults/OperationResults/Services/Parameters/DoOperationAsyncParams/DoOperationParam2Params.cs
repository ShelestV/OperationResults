using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncParam<T1, T2> : OperationAsyncParam
{
    private readonly DoOperationAsync<T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    
    public DoOperationAsyncParam(DoOperationAsync<T1, T2> operation, T1 value1, T2 value2, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result, this.value1, this.value2);
    }
}
