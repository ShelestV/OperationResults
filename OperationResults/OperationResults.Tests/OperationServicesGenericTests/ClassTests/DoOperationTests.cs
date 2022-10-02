﻿using OperationResults.Services;
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
		var result = OperationService.DoOperation<string>(DoneOperation);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(StringResult);
    }

	[Fact]
	public void DoOperation_Success_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);

		var result = OperationService.DoOperation(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_FailWithExceptionThrowing_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string, Exception>(ThrowException, this.exception);

		var result = OperationService.DoOperation(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void DoOperation_Success_Delegate_Test()
	{
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperation<string>(DoneOperation, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_Success_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperation(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
	public void DoOperation_FailWithExceptionThrowing_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<string>(DoneOperation);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperation(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(StringResult);
	}

	[Fact]
    public void DoOperation_Fail_Test()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<string, Exception>(FailOperation, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperation_NotFound_Test()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<string>(NotFound),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static void DoneOperation(IOperationResult<string> result)
    {
        result.Done(StringResult);
    }

    private static void FailOperation(IOperationResult<string> result, Exception ex)
    {
        result.Fail(ex);
    }

    private static void ThrowException(IOperationResult<string> result, Exception ex)
    {
        throw ex;
    }

    private static void NotFound(IOperationResult<string> result)
    {
        result.NotFound();
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
