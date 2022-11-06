using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ServicesTests;

public class OperationServicesLogicTests
{
    private const string Result = "Test";
    private const string ExceptionMessage = "Test";
    
    #region NotFound
    [Fact]
    public void NotFound_Test()
    {
        var result = OperationResultFactory.Create();
        OperationService.NotFound(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void NotFound_WithLog_Test()
    {
        var result = OperationResultFactory.Create();
        var logParam = LogParamsFactory.Create(() => { });

        OperationService.NotFound(result, logParam);
        
        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void NotFound_Generic_Test()
    {
        var result = OperationResultFactory.Create<string>();
        OperationService.NotFound(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }

    [Fact]
    public void NotFound_Generic_WithLog_Test()
    {
        var result = OperationResultFactory.Create<string>();
        var logParam = LogParamsFactory.Create(() => { });

        OperationService.NotFound(result, logParam);
        
        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }
    #endregion
    
    #region Fail
    private readonly Exception exception = new Exception(ExceptionMessage);
    
    [Fact]
    public void FailOperation_Test()
    {
        var result = OperationResultFactory.Create();
        OperationService.FailOperation(exception, result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void FailOperation_WithLog_Test()
    {
        var result = OperationResultFactory.Create();
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        OperationService.FailOperation(exception, result, logParam);
        
        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void FailOperation_Generic_Test()
    {
        var result = OperationResultFactory.Create<string>();
        OperationService.FailOperation(exception, result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void FailOperation_Generic_WithLog_Test()
    {
        var result = OperationResultFactory.Create<string>();
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        OperationService.FailOperation(exception, result, logParam);
        
        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    #endregion

    #region Non Generic
    [Fact]
    public async Task DoSimpleOperationAsync_Success_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => Task.CompletedTask);

        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoSimpleOperationAsync_ThrowException_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => throw new Exception(ExceptionMessage));

        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public async Task DoSimpleOperationAsync_ThrowException_WithLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = await OperationService.DoOperationAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    
    [Fact]
    public async Task DoOperationAsync_Success_Test()
    {
        var param = AsyncParamsFactory.Create(result =>
        {
            result.Done();
            return Task.CompletedTask;
        });

        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_ThrowException_Test()
    {
        var param = AsyncParamsFactory.Create(_ => throw new Exception(ExceptionMessage));

        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public async Task DoOperationAsync_ThrowException_WithLog_Test()
    {
        var param = AsyncParamsFactory.Create(_ => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = await OperationService.DoOperationAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    
    [Fact]
    public void DoSimpleOperation_Success_Test()
    {
        var param = ParamsFactory.CreateSimple(() => { });

        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoSimpleOperation_ThrowException_Test()
    {
        var param = ParamsFactory.CreateSimple(() => throw new Exception(ExceptionMessage));

        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void DoSimpleOperation_ThrowException_WithLog_Test()
    {
        var param = ParamsFactory.CreateSimple(() => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = OperationService.DoOperation(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    
    [Fact]
    public void DoOperation_Success_Test()
    {
        var param = ParamsFactory.Create(result =>
        {
            result.Done();
        });

        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_ThrowException_Test()
    {
        var param = ParamsFactory.Create(_ => throw new Exception(ExceptionMessage));

        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void DoOperation_ThrowException_WithLog_Test()
    {
        var param = ParamsFactory.Create(_ => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = OperationService.DoOperation(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    #endregion

    #region Generic
    [Fact]
    public async Task DoSimpleOperationWithResultAsync_Success_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => Task.FromResult(Result));

        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoSimpleOperationWithResultAsync_ThrowException_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult<string>(() => throw new Exception(ExceptionMessage));

        var result = await OperationService.DoOperationWithResultAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public async Task DoSimpleOperationWithResultAsync_ReturnNull_WithLog_WithNotFoundLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(() => Task.FromResult<string>(null));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });
        var notFoundLog = LogParamsFactory.Create<string>(message =>
        {
            using var _ = new AssertionScope();
            message.Should().Be(ExceptionMessage);
        }, ExceptionMessage);
        
        var result = await OperationService.DoOperationWithResultAsync(param, logParam, notFoundLog);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }
    
    [Fact]
    public async Task DoOperationWithResultAsync_Success_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<string>(result =>
        {
            result.Done(Result);
            return Task.CompletedTask;
        });

        var result = await OperationService.DoOperationWithResultAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_ThrowException_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<string>(_ => throw new Exception(ExceptionMessage));

        var result = await OperationService.DoOperationWithResultAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_ThrowException_WithLog_WithNotFoundLog_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<string>(_ => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = await OperationService.DoOperationWithResultAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    
    [Fact]
    public void DoSimpleOperationWithResult_Success_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult<string>(() => Result);

        var result = OperationService.DoOperationWithResult(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoSimpleOperationWithResult_ThrowException_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult<string>(() => throw new Exception(ExceptionMessage));

        var result = OperationService.DoOperationWithResult(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void DoSimpleOperationWithResult_ThrowException_WithLog_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult<string>(() => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = OperationService.DoOperationWithResult(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void DoSimpleOperationWithResult_ReturnNull_WithLog_WithNotFoundLog_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult<string>(() => null);
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });
        var notFoundLog = LogParamsFactory.Create<string>(message =>
        {
            using var _ = new AssertionScope();
            message.Should().Be(ExceptionMessage);
        }, ExceptionMessage);

        var result = OperationService.DoOperationWithResult(param, logParam, notFoundLog);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.NotFound);
    }
    
    [Fact]
    public void DoOperationWithResult_Success_Test()
    {
        var param = ParamsFactory.CreateWithResult<string>(result =>
        {
            result.Done(Result);
        });

        var result = OperationService.DoOperationWithResult(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_ThrowException_Test()
    {
        var param = ParamsFactory.CreateWithResult<string>(_ => throw new Exception(ExceptionMessage));

        var result = OperationService.DoOperationWithResult(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }

    [Fact]
    public void DoOperationWithResult_ThrowException_WithLog_Test()
    {
        var param = ParamsFactory.CreateWithResult<string>(_ => throw new Exception(ExceptionMessage));
        var logParam = LogParamsFactory.Create(error =>
        {
            using var _ = new AssertionScope();
            error.Should().Contain(ExceptionMessage);
        });

        var result = OperationService.DoOperationWithResult(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.BadFlow);
    }
    #endregion
}