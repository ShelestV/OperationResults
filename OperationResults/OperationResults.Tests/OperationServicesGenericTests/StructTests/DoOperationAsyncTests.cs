using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public async Task DoOperationAsyncSuccessTest()
    {
        var logMessage = LogMessage;
        var guid = Guid.NewGuid();

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<Guid, Guid>(DoOperationAsync, guid),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(guid);
    }

    [Fact]
    public async Task DoOperationAsyncFailTest()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<Guid, Exception>(FailOperationAsync, this.exception),
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
            new Services.Parameters.Generic.DoOperationAsyncParam<Guid, Exception>(ThrowExceptionAsync, this.exception),
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
            new Services.Parameters.Generic.DoOperationAsyncParam<Guid>(NotFoundAsync),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static async Task DoOperationAsync(IOperationResult<Guid> result, Guid guid)
    {
        await Task.Run(() => result.Done(guid));
    }

    private static async Task FailOperationAsync(IOperationResult<Guid> result, Exception ex)
    {
        await Task.Run(() => result.Fail(ex));
    }

    private static async Task ThrowExceptionAsync(IOperationResult<Guid> result, Exception ex)
    {
        await Task.Run(() => { });
        throw ex;
    }

    private static async Task NotFoundAsync(IOperationResult<Guid> result)
    {
        await Task.Run(() => result.NotFound());
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
