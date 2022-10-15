using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class DoOperationAsyncTests
{
    private static readonly Guid guid = Guid.Parse("36cf91f0-afb2-4748-b313-dd31cb368f5e");

    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

	[Fact]
	public async Task DoOperationAsync_Success_Delegate_WithoutLog_Test()
	{
		var result = await OperationService.DoOperationAsync<Guid>(DoOperationAsync);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guid);
	}

	[Fact]
    public async Task DoOperationAsync_Success_Param_WithoutLog_Test()
    {
        var operationParam = new Services.Parameters.Generic.DoOperationAsyncParam<Guid>(DoOperationAsync);

		var result = await OperationService.DoOperationAsync(operationParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(guid);
    }

    [Fact]
	public async Task DoOperationAsync_FailWithThrowingException_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationAsyncParam<Guid, Exception>(ThrowExceptionAsync, this.exception);

		var result = await OperationService.DoOperationAsync(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public async Task DoOperationAsync_Success_Delegate_Test()
	{
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = await OperationService.DoOperationAsync<Guid>(DoOperationAsync, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guid);
	}

	[Fact]
	public async Task DoOperationAsync_Success_Param_Test()
	{
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = await OperationService.DoOperationAsync<Guid>(DoOperationAsync, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guid);
	}

	[Fact]
    public async Task DoOperationAsync_Fail_Test()
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
    public async Task DoOperationAsync_FailWithExceptionThrowing_Test()
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
    public async Task DoOperationAsync_NotFound_Test()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<Guid>(NotFoundAsync),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static Task<Guid> DoOperationAsync(IOperationResult<Guid> result)
    {
	    return Task.FromResult(guid);
    }

    private static Task<Guid> FailOperationAsync(IOperationResult<Guid> result, Exception ex)
    {
	    result.Fail(ex);
	    return Task.FromResult(Guid.Empty);
    }

    private static Task<Guid> ThrowExceptionAsync(IOperationResult<Guid> result, Exception ex)
    {
        throw ex;
    }

    private static Task<Guid> NotFoundAsync(IOperationResult<Guid> result)
    {
	    result.NotFound();
	    return Task.FromResult(Guid.Empty);
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
