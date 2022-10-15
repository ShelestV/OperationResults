using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    private static readonly Guid guidResult = Guid.Parse("36cf91f0-afb2-4748-b313-dd31cb368f5e");

	[Fact]
	public void DoOperation_Success_Delegate_WithoutLog_Test()
	{
		var result = OperationService.DoOperation<Guid>(DoneOperation);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guidResult);
	}

	[Fact]
	public void DoOperation_Success_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<Guid>(DoneOperation);

		var result = OperationService.DoOperation(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guidResult);
	}

	[Fact]
	public void DoOperation_FailWithExceptionThrowing_Param_WithoutLog_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<Guid, Exception>(ThrowException, this.exception);

		var result = OperationService.DoOperation(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void DoOperation_Success_Delegate_Test()
	{
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperation<Guid>(DoneOperation, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guidResult);
	}

	[Fact]
	public void DoOperation_Success_Param_Test()
	{
		var operationParam = new Services.Parameters.Generic.DoOperationParam<Guid>(DoneOperation);
		var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

		var result = OperationService.DoOperation(operationParam, logParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(guidResult);
	}

	[Fact]
    public void DoOperationFailTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<Guid, Exception>(FailOperation, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperationFailWithExceptionThrowingTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<Guid, Exception>(ThrowException, this.exception),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperationNotFoundTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<Guid>(NotFound),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static Guid DoneOperation(IOperationResult<Guid> result)
    {
	    return guidResult;
    }

    private static Guid FailOperation(IOperationResult<Guid> result, Exception ex)
    {
        result.Fail(ex);
        return Guid.Empty;
    }

    private static Guid ThrowException(IOperationResult<Guid> result, Exception ex)
    {
        throw ex;
    }

    private static Guid NotFound(IOperationResult<Guid> result)
    {
        result.NotFound();
        return Guid.Empty;
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
