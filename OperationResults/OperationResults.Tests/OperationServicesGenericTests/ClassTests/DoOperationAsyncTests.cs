using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    private const string StringResult = "Success";

    [Fact]
    public async Task DoOperationAsync_Success_Delegate_WithoutLog_Test()
    {
		var result = await OperationService.DoOperationWithResultAsync<string>(DoOperationAsync);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(StringResult);
    }

    [Fact]
    public async Task DoOperationAsync_Success_Param_WithoutLog_Test()
    {
		var operationParam = new Services.Parameters.Generic.DoOperationAsyncParam<string>(DoOperationAsync);

		var result = await OperationService.DoOperationWithResultAsync(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

    [Fact]
    public async Task DoOperationAsync_FailWithThrowingException_WithoutLog_Test()
    {
		var operationParam = new Services.Parameters.Generic.DoOperationAsyncParam<string, Exception>(ThrowExceptionAsync, this.exception);

		var result = await OperationService.DoOperationWithResultAsync(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

    [Fact]
	public async Task DoOperationAsync_Success_Delegate_Test()
	{
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = await OperationService.DoOperationWithResultAsync<string>(DoOperationAsync, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public async Task DoOperationAsync_Success_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationAsyncParam<string>(DoOperationAsync);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = await OperationService.DoOperationWithResultAsync(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
    public async Task DoOperationAsync_Fail_Test()
    {
        var logMessage = LogMessage;

        var result = await OperationService.DoOperationWithResultAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string, Exception>(FailOperationAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsync_FailWithExceptionThrowing_Test()
    {
	    var result = await OperationService.DoOperationWithResultAsync(
            AsyncParamsFactory.CreateWithResult<string, Exception>(ThrowExceptionAsync, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsync_NotFound_Test()
    {
	    var result = await OperationService.DoOperationWithResultAsync(
            new Services.Parameters.Generic.DoOperationAsyncParam<string>(NotFoundAsync),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public async Task DoOperationAsync_AnonymousMethod_Test()
    {
	    var operationParam = AsyncParamsFactory.CreateWithResult(async () => await Task.FromResult(StringResult));

	    var result = await OperationService.DoOperationWithResultAsync(operationParam);

	    using var _ = new AssertionScope();
	    result.State.Should().Be(OperationResultState.Ok);
    }
    
    private static Task<string> DoOperationAsync(IOperationResult<string> result)
    {
        return Task.FromResult(StringResult);
    }

    private static Task<string> FailOperationAsync(IOperationResult<string> result, Exception ex)
    {
        result.Fail(ex);
        return Task.FromResult(string.Empty);
    }

    private static Task<string> ThrowExceptionAsync(IOperationResult<string> result, Exception ex)
    {
        throw ex;
    }

    private static Task<string> NotFoundAsync(IOperationResult<string> result)
    {
	    result.NotFound();
	    return Task.FromResult(string.Empty);
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
