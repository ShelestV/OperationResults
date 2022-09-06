namespace OperationResults.Exceptions;

public class OperationResultNullException : Exception
{
	public OperationResultNullException() : base(Constants.NullResultExceptionMessage)
	{
	}
}
