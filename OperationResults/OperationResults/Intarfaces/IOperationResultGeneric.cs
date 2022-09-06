namespace OperationResults.Generic;

public interface IOperationResult<TResult>
{
	OperationResultState State { get; }
	TResult Result { get; }
	Exception Exception { get; }
	void Done(TResult result);
	void Fail(Exception exception);
	void NotFound();
}
