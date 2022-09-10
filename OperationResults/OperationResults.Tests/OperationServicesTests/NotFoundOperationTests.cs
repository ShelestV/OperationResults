using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesTests;

public class NotFoundOperationTests
{
    private const string LogMessage = "Test message";

    private IOperationResult result = OperationResultFactory.Create();

    private void ResetResult()
    {
        result = OperationResultFactory.Create();
    }

    [Fact]
    public void NotFoundOperationWithNullLog()
    {
        this.ResetResult();

        OperationService.NotFound(this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void NotFoundOperationWithLog()
    {
        this.ResetResult();
        var logMessage = LogMessage;

        OperationService.NotFound(this.result,
            () => logMessage = LogMessage);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
