namespace OperationResults.Generic;

public interface IOperationResult<TResult>
{
	OperationResultState State { get; }
	TResult Result { get; }
	Exception Exception { get; }
	void Done(TResult res);
	void Fail(Exception exception);
	void NotFound();
}
