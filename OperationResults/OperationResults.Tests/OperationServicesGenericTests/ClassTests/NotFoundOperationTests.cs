using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests; 

public class NotFoundOperationTests 
{
    private const string LogMessage = "Test message";

    private IOperationResult<string> result = OperationResultFactory.Create<string>();

    private void ResetResult()
    {
        result = OperationResultFactory.Create<string>();
    }

    [Fact]
    public void FailOperationWithNullLog()
    {
        this.ResetResult();

        OperationService.NotFound(this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();

        OperationService.NotFound(this.result,
            new LogOperationParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    private static void Log(string logMessage)
    {
    }
}
