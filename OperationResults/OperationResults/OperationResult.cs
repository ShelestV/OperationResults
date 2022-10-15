namespace OperationResults;

public class OperationResult : 
	Abstractions.OperationResultBase, 
	IOperationResult
{
	public void Done()
	{
		if (!this.CouldChangeState()) return;
		
		this.State = OperationResultState.Ok;
	}
}
