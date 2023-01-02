namespace OperationResults.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException() : base("Result is null")
    {
    }
}