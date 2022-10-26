using OperationResults.Exceptions;

namespace OperationResults.Abstractions;

public abstract class OperationResultBase
{
	private Exception? exception;

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

	public void Fail(Exception ex)
	{
		if (!this.CouldChangeState()) return;
		
		this.exception = ex;
		this.State = OperationResultState.BadFlow;
	}

	public void NotFound()
	{
		if (!this.CouldChangeState()) return;
		
		this.State = OperationResultState.NotFound;
	}

	protected bool CouldChangeState()
	{
		return this.State == OperationResultState.Processing;
	}
}
