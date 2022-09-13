using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.ClassTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public void DoOperationSuccessTest()
    {
        var logMessage = LogMessage;
        var str = "Test";

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<string, string>(DoneOperation, str),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(str);
    }

    [Fact]
    public void DoOperationFailTest()
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
    public void DoOperationFailWithExceptionThrowingTest()
    {
        var logMessage = LogMessage;

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<string, Exception>(ThrowException, this.exception),
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
            new Services.Parameters.Generic.DoOperationParam<string>(NotFound),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static void DoneOperation(IOperationResult<string> result, string str)
    {
        result.Done(str);
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
