namespace OperationResults.Exceptions;

public class OperationStillProcessingException : Exception
{
	public OperationStillProcessingException() : base(Constants.ProcessingOperationExceptionMessage)
	{
	}
}
