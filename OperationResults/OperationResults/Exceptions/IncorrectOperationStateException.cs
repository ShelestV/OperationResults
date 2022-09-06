namespace OperationResults.Exceptions;

public class IncorrectOperationResultStateException : OperationException
{
	public IncorrectOperationResultStateException() : base(Constants.IncorrectOperationStateExceptionMessage)
	{
	}
}
