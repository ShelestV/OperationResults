using OperationResults.Services;

namespace OperationResults.Tests.OperationServicesTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";

    [Fact]
    public async Task DoOperationAsyncSuccessTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            async (result) => await Task.Run(() => result.Done()),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        logMessage.Should().Be(LogMessage);
    }

    [Fact]
    public async Task DoOperationAsyncFailTest()
    {
        var logMessage = LogMessage;
        var exception = new Exception("Test exception");

        var result = await OperationService.DoOperationAsync(
            async (result) => await Task.Run(() => result.Fail(exception)),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
        logMessage.Should().Be(LogMessage);
    }

    [Fact]
    public async Task DoOperationAsyncFailWithExceptionThrowingTest()
    {
        var logMessage = LogMessage;
        var exception = new Exception("Test exception");

        var result = await OperationService.DoOperationAsync(
            async (result) => { await Task.Run(() => { }); throw exception; },
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
        logMessage.Should().NotBe(LogMessage);
        logMessage.Should().Contain(LogMessage);
        logMessage.Should().Contain(exception.Message);
    }

    [Fact]
    public async Task DoOperationAsyncNotFoundTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            async (result) => await Task.Run(() => result.NotFound()),
            (logSuffix) => logMessage = LogMessage + logSuffix);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
        logMessage.Should().Be(LogMessage);
    }
}
