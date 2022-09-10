using OperationResults.Services;

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

        OperationService<string>.NotFound(this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();
        var logMessage = LogMessage;

        OperationService<string>.NotFound(this.result,
            () => logMessage = LogMessage);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
