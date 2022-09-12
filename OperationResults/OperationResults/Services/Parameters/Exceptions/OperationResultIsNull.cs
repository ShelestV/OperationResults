namespace OperationResults.Services.Parameters.Exceptions;

public sealed class OperationResultIsNull : Exception
{
    public OperationResultIsNull() : base("Operation result is not set")
    {
    }
}
