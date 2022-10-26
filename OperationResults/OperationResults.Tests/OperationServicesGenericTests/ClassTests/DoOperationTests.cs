using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    private const string StringResult = "Success";

    [Fact]
    public void DoOperation_Success_Delegate_WithoutLog_Test()
    {
		var result = OperationService.DoOperationWithResult<string>(DoneOperation);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(StringResult);
    }

	[Fact]
	public void DoOperation_Success_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);

		var result = OperationService.DoOperationWithResult(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_FailWithExceptionThrowing_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string, Exception>(ThrowException, this.exception);

		var result = OperationService.DoOperationWithResult(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void DoOperation_Success_Delegate_Test()
	{
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperationWithResult<string>(DoneOperation, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_Success_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperationWithResult(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_FailWithExceptionThrowing_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperationWithResult(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
    public void DoOperation_Fail_Test()
    {
	    var result = OperationService.DoOperationWithResult(
            new Services.Parameters.Generic.DoOperationParam<string, Exception>(FailOperation, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperation_NotFound_Test()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperationWithResult(
            new Services.Parameters.Generic.DoOperationParam<string>(NotFound),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static string DoneOperation(IOperationResult<string> result)
    {
	    return StringResult;
    }

    private static string FailOperation(IOperationResult<string> result, Exception ex)
    {
        result.Fail(ex);
        return string.Empty;
    }

    private static string ThrowException(IOperationResult<string> result, Exception ex)
    {
        throw ex;
    }

    private static string NotFound(IOperationResult<string> result)
    {
        result.NotFound();
        return string.Empty;
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
