namespace OperationResults;

public interface IOperationResult
{
	OperationResultState State { get; }
	Exception Exception { get; }
	void Done();
	void Fail(Exception exception);
	void NotFound();
}
