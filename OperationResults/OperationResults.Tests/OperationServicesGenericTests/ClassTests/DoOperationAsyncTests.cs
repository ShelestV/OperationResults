using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public async Task DoOperationAsyncSuccessTest()
    {
        var logMessage = LogMessage;
        var str = "Test result";

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string, string>(DoOperationAsync, str),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(str);
    }

    [Fact]
    public async Task DoOperationAsyncFailTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string, Exception>(FailOperationAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsyncFailWithExceptionThrowingTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string, Exception>(ThrowExceptionAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsyncNotFoundTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string>(NotFoundAsync),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static async Task DoOperationAsync(IOperationResult<string> result, string str)
    {
        await Task.Run(() => result.Done(str));
    }

    private static async Task FailOperationAsync(IOperationResult<string> result, Exception ex)
    {
        await Task.Run(() => result.Fail(ex));
    }

    private static async Task ThrowExceptionAsync(IOperationResult<string> result, Exception ex)
    {
        await Task.Run(() => { });
        throw ex;
    }

    private static async Task NotFoundAsync(IOperationResult<string> result)
    {
        await Task.Run(() => result.NotFound());
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
