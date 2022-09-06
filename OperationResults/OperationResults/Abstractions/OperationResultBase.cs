using OperationResults.Exceptions;

namespace OperationResults.Abstractions;

public abstract class OperationResultBase
{
	protected Exception? exception;

	public OperationResultState State { get; protected set; }
	public Exception Exception
	{
		get
		{
			if (this.State == OperationResultState.Processing)
				throw new OperationStillProcessingException();

			if (this.State != OperationResultState.BadFlow)
				throw new IncorrectOperationResultStateException();

			if (this.exception is null)
				throw new OperationExceptionNullException();

			return this.exception;
		}
	}

	protected OperationResultBase()
	{
		this.State = OperationResultState.Processing;
		this.exception = null;
	}

	public void Fail(Exception exception)
	{
		this.exception = exception;
		this.State = OperationResultState.BadFlow;
	}

	public void NotFound()
	{
		this.State = OperationResultState.NotFound;
	}
}
