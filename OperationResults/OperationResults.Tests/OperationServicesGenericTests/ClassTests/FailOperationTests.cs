using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests; 

public class FailOperationTests 
{
    private const string LogMessage = "Test message";

    private IOperationResult<string> result = OperationResultFactory.Create<string>();
    private readonly Exception exception = new("Test exception");

    private void ResetResult()
    {
        result = OperationResultFactory.Create<string>();
    }

    [Fact]
    public void FailOperationWithNullLog()
    {
        this.ResetResult();

        OperationService<string>.FailOperation(this.exception, this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();
        var logMessage = LogMessage;

        OperationService<string>.FailOperation(this.exception, this.result,
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
        logMessage.Should().NotBe(LogMessage);
        logMessage.Should().Contain(LogMessage);
        logMessage.Should().Contain(this.exception.Message);
    }
}
