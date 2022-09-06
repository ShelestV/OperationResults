namespace OperationResults.Exceptions;

public class OperationExceptionNullException : Exception
{
	public OperationExceptionNullException() : base(Constants.NullExceptionExceptionMessage)
	{
	}
}
