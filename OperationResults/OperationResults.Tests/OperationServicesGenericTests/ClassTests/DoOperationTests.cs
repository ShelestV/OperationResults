using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";

    [Fact]
    public void DoOperationSuccessTest()
    {
        var logMessage = LogMessage;
        var str = "Test";

        var result = OperationService<string>.DoOperation(
            (result) => result.Done(str),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(str);
        logMessage.Should().Be(LogMessage);
    }

    [Fact]
    public void DoOperationFailTest()
    {
        var logMessage = LogMessage;
        var exception = new Exception("Test exception");

        var result = OperationService<string>.DoOperation(
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

        var result = OperationService<string>.DoOperation(
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

        var result = OperationService<string>.DoOperation(
            (result) => result.NotFound(),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
