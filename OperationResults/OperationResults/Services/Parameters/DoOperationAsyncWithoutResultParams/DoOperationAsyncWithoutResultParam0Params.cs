using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public class DoOperationAsyncWithoutResultParam : OperationAsyncParam
{
    private readonly Func<Task> operation;

    public DoOperationAsyncWithoutResultParam(Func<Task> operation)
    {
        this.operation = operation;
    }

    public override Task InvokeAsync(IOperationResult result)
    {
        return this.operation.Invoke();
    }
}