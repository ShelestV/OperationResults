using OperationResults.Exceptions;

namespace OperationResults.Generic;

public class OperationResult<TResult> :
	Abstractions.OperationResultBase,
	IOperationResult<TResult>
{
	private TResult? result;
	public TResult Result
	{
		get
		{
			if (this.State == OperationResultState.Processing)
				throw new OperationStillProcessingException();

			if (this.State != OperationResultState.Ok)
				throw new IncorrectOperationResultStateException();

			if (this.result is null)
				throw new OperationResultNullException();

			return result;
		}
	}

	public void Done(TResult res)
	{
		if (!this.CouldChangeState()) return;
		
		this.State = OperationResultState.Ok;
		this.result = res;
	}
}
