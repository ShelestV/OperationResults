using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.OperationServicesGenericTests.StructTests;

public class DoOperationTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public void DoOperationSuccessTest()
    {
        var logMessage = LogMessage;
        var guid = Guid.NewGuid();

        var result = OperationService.DoOperation(
            new Services.Parameters.Generic.DoOperationParam<Guid, Guid>(DoneOperation, guid),
            new LogOperationWithSuffixParam<string>(Log, logMessage));

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(guid);
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

    private static void DoneOperation(IOperationResult<Guid> result, Guid guid)
    {
        result.Done(guid);
    }

    private static void FailOperation(IOperationResult<Guid> result, Exception ex)
    {
        result.Fail(ex);
    }

    private static void ThrowException(IOperationResult<Guid> result, Exception ex)
    {
        throw ex;
    }

    private static void NotFound(IOperationResult<Guid> result)
    {
        result.NotFound();
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
