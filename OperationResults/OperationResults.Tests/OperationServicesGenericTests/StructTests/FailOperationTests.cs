using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class FailOperationTests
{
    private const string LogMessage = "Test message";

    private IOperationResult<Guid> result = OperationResultFactory.Create<Guid>();
    private readonly Exception exception = new("Test exception");

    private void ResetResult()
    {
        result = OperationResultFactory.Create<Guid>();
    }

    [Fact]
    public void FailOperationWithNullLog()
    {
        this.ResetResult();

        OperationService<Guid>.FailOperation(this.exception, this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();
        var logMessage = LogMessage;

        OperationService<Guid>.FailOperation(this.exception, this.result,
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
        logMessage.Should().NotBe(LogMessage);
        logMessage.Should().Contain(LogMessage);
        logMessage.Should().Contain(this.exception.Message);
    }
}
