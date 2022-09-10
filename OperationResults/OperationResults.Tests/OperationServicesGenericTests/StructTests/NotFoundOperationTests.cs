using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class NotFoundOperationTests
{
    private const string LogMessage = "Test message";

    private IOperationResult<Guid> result = OperationResultFactory.Create<Guid>();

    private void ResetResult()
    {
        result = OperationResultFactory.Create<Guid>();
    }

    [Fact]
    public void FailOperationWithNullLog()
    {
        this.ResetResult();

        OperationService<Guid>.NotFound(this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();
        var logMessage = LogMessage;

        OperationService<Guid>.NotFound(this.result,
            () => logMessage = LogMessage);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
