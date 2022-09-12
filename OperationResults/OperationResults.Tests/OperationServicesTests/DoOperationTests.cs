using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public void DoOperationSuccessTest()
    {
        var result = OperationService.DoOperation(
            new DoOperationParam(DoneOperation), 
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationFailTest()
    {
        var result = OperationService.DoOperation(
            new DoOperationParam<Exception>(FailOperation, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperationFailWithExceptionThrowingTest()
    {
        var result = OperationService.DoOperation(
            new DoOperationParam<Exception>(ThrowException, this.exception),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public void DoOperationNotFoundTest()
    {
        var result = OperationService.DoOperation(
            new DoOperationParam(NotFound),
            new LogOperationWithSuffixParam<string>(Log, LogMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    private static void DoneOperation(IOperationResult result)
    {
        result.Done();
    }

    private static void FailOperation(IOperationResult result, Exception ex)
    {
        result.Fail(ex);
    }

    private static void ThrowException(IOperationResult result, Exception ex)
    {
        throw ex;
    }

    private static void NotFound(IOperationResult result)
    {
        result.NotFound();
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
