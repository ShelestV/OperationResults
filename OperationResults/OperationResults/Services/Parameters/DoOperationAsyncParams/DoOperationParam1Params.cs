using OperationResults.Services.Delegates;
using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationAsyncParam<T1> : OperationAsyncParam
{
    private readonly DoOperationAsync<T1> operation;
    private readonly T1 value1;
    
    public DoOperationAsyncParam(DoOperationAsync<T1> operation, T1 value1, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override async Task InvokeAsync(IOperationResult result)
    {
        await this.operation.Invoke(result, this.value1);
    }
}
