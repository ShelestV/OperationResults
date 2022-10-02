namespace OperationResults.Tests.ExceptionTests;

public class OperationResultNullExceptionTests
{
	[Fact]
	public void CreateException_Success_Test()
	{
		var ex = new OperationResultNullException();
		ex.Message.Should().Be(Constants.NullResultExceptionMessage);
	}
}
