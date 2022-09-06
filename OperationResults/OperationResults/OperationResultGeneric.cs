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

	public void Done(TResult result)
	{
		this.State = OperationResultState.Ok;
		this.result = result;
	}
}
