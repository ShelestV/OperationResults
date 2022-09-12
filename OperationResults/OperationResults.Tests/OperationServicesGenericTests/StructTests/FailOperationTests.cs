using OperationResults.Services;
using OperationResults.Services.Parameters;

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

        OperationService.FailOperation(this.exception, this.result);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
    }

    [Fact]
    public void FailOperationWithLog()
    {
        this.ResetResult();

        OperationService.FailOperation(this.exception, this.result,
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Exception.Should().Be(this.exception);
    }

    private void Log(string logSuffix, string logMessage)
    {
        logSuffix.Should().Contain(this.exception.Message);
    }
}
