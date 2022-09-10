using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";

    [Fact]
    public void DoOperationSuccessTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            (result) => result.Done(),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        logMessage.Should().Be(LogMessage);
    }

    [Fact]
    public void DoOperationFailTest()
    {
        var logMessage = LogMessage;
        var exception = new Exception("Test exception");

        var result = OperationService.DoOperation(
            (result) => result.Fail(exception),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
        logMessage.Should().Be(LogMessage);
    }

    [Fact]
    public void DoOperationFailWithExceptionThrowingTest()
    {
        var logMessage = LogMessage;
        var exception = new Exception("Test exception");

        var result = OperationService.DoOperation(
            (result) => throw exception,
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
        logMessage.Should().NotBe(LogMessage);
        logMessage.Should().Contain(logMessage);
    }

    [Fact]
    public void DoOperationNotFoundTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            (result) => result.NotFound(),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
