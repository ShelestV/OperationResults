namespace OperationResults;

public class OperationResult : 
	Abstractions.OperationResultBase, 
	IOperationResult
{
	public void Done()
	{
		this.State = OperationResultState.Ok;
	}
}
