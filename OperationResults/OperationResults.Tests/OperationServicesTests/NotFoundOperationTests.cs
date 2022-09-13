using OperationResults.Services;
using OperationResults.Services.Parameters;

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

        OperationService.NotFound(this.result,
            new LogOperationParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
    }

    private static void Log(string logMessage)
    {
        logMessage.Should().Be(LogMessage);
    }
}
