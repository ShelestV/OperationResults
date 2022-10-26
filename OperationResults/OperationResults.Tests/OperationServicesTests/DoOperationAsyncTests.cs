using OperationResults.Services;
using OperationResults.Services.Parameters;


namespace OperationResults.Tests.OperationServicesTests;

public class DoOperationAsyncTests
{
    private const string LogMessage = "Test message";
    private readonly Exception exception = new("Test exception");

    [Fact]
    public async Task DoOperationAsync_Success_Param_WithoutLog_Test()
    {
        var operationParam = new DoOperationAsyncParam(DoOperationAsync);

        var result = await OperationService.DoOperationAsync(operationParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Success_LambdaWithIOperationResult_Test()
    {
        var result = await OperationService.DoOperationAsync( result =>
        {
            result.Done();
            return Task.CompletedTask;
        });

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Success_LambdaWithoutIOperationResult_Test()
    {
        var result = await OperationService.DoOperationAsync(() => Task.CompletedTask);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public async Task DoOperationAsync_Success_MethodWithIOperationResult_Test()
    {
        var result = await OperationService.DoOperationAsync(DoOperationAsync);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Success_MethodWithoutIOperationResult_Test()
    {
        var result = await OperationService.DoOperationAsync(DoOperationAsyncWithoutResult);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Fail_Param_WithoutLog_Test()
    {
		var operationParam = new DoOperationAsyncParam<Exception>(ThrowExceptionAsync, this.exception);

		var result = await OperationService.DoOperationAsync(operationParam);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
	}

    [Fact]
    public async Task DoOperationAsync_Success_Delegate_Test()
    {
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

        var result = await OperationService.DoOperationAsync(DoOperationAsync, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

	[Fact]
    public async Task DoOperationAsync_Success_Param_Test()
    {
        var operationParam = new DoOperationAsyncParam(DoOperationAsync);
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

        var result = await OperationService.DoOperationAsync(operationParam, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Fail_Test()
    {
        var operationParam = new DoOperationAsyncParam<Exception>(FailOperationAsync, this.exception);
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

        var result = await OperationService.DoOperationAsync(operationParam, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsync_Fail_WithExceptionThrowing_Test()
    {
        var operationParam = AsyncParamsFactory.Create(ThrowExceptionAsync, this.exception);
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

        var result = await OperationService.DoOperationAsync(operationParam, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
        result.Exception.Should().Be(exception);
    }

    [Fact]
    public async Task DoOperationAsync_NotFound_Test()
    {
        var operationParam = new DoOperationAsyncParam(NotFoundAsync);
        var logParam = new LogOperationWithSuffixParam<string>(Log, LogMessage);

        var result = await OperationService.DoOperationAsync(operationParam, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }
    
    private static async Task DoOperationAsync(IOperationResult result)
    {
        await Task.Run(result.Done);
    }

    private static async Task DoOperationAsyncWithoutResult()
    {
        await Task.Run(() => { });
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
        await Task.Run(result.NotFound);
    }

    private void Log(string errorSuffix, string errorMessage)
    {
        errorSuffix.Should().Contain(this.exception.Message);
    }
}
