using OperationResults.Services;
using OperationResults.Services.Parameters;

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
        LogMessage.Should().Be(LogMessage);
    }

    private static void Log(string logMessage)
    {
        logMessage = LogMessage + "Test";
    }
}
