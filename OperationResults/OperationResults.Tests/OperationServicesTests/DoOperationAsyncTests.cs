using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public async Task DoOperationAsyncSuccessTest()
    {
        var operationParam = ParamsFactory.CreateParam(DoOperationAsync);
        var logParam = ParamsFactory.CreateLogParam(Log, LogMessage);
        var result = await OperationService.DoOperationAsync(operationParam, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsyncFailTest()
    {
        var result = await OperationService.DoOperationAsync(
            new DoOperationAsyncParam<Exception>(FailOperationAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsyncFailWithExceptionThrowingTest()
    {
        var result = await OperationService.DoOperationAsync(
            new DoOperationAsyncParam<Exception>(ThrowExceptionAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsyncNotFoundTest()
    {
        var result = await OperationService.DoOperationAsync(
            new DoOperationAsyncParam(NotFoundAsync),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private async Task DoOperationAsync(IOperationResult result)
    {
        await Task.Run(() => result.Done());
    }

    private static async Task FailOperationAsync(IOperationResult result, Exception ex)
    {
        await Task.Run(() => result.Fail(ex));
    }

    private static async Task ThrowExceptionAsync(IOperationResult result, Exception ex)
    {
        await Task.Run(() => { });
        throw ex;
    }

    private static async Task NotFoundAsync(IOperationResult result)
    {
        await Task.Run(() => result.NotFound());
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
