using OperationResults.Services;
using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ServicesTests;

public class OperationServicesCallingTests
{
    #region DoOperationAsync
    [Fact]
    public async Task DoOperationAsync_SimpleOperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => Task.CompletedTask);
        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_SimpleFunc_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(() => Task.CompletedTask);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_SimpleMethod_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(DoWithoutOperationResultAsync);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_OperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = AsyncParamsFactory.Create(result =>
        {
            result.Done();
            return Task.CompletedTask;
        });
        var result = await OperationService.DoOperationAsync(param, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Func_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(result =>
        {
            result.Done();
            return Task.CompletedTask;
        }, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Method_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(DoAsync, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public async Task DoOperationAsync_OperationParam_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var param = AsyncParamsFactory.Create(_ => Task.CompletedTask);
        var result = await OperationService.DoOperationAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Func_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(_ => Task.CompletedTask);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Method_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationAsync(DoWithoutFinishOperationAsync);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public async Task DoOperationAsync_SimpleOperationParam_WithoutParameters_WithLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() => Task.CompletedTask);
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_SimpleFunc_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(() => Task.CompletedTask, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_SimpleMethod_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(DoWithoutOperationResultAsync, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_OperationParam_WithoutParameters_WithLog_Test()
    {
        var param = AsyncParamsFactory.Create(result =>
        {
            result.Done();
            return Task.CompletedTask;
        });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(param, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Func_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(result =>
        {
            result.Done();
            return Task.CompletedTask;
        }, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Method_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(DoAsync, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public async Task DoOperationAsync_OperationParam_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var param = AsyncParamsFactory.Create(_ => Task.CompletedTask);
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Func_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(_ => Task.CompletedTask, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_Method_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationAsync(DoWithoutFinishOperationAsync, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion

    #region DoOperation
    [Fact]
    public void DoOperation_SimpleOperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = ParamsFactory.CreateSimple(() => { });
        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_SimpleFunc_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(() => { });

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_SimpleMethod_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(DoWithoutOperationResult);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_OperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = ParamsFactory.Create(result =>
        {
            result.Done();
        });
        var result = OperationService.DoOperation(param, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Func_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(result =>
        {
            result.Done();
        }, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Method_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(Do, finishOperation: false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public void DoOperation_OperationParam_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var param = ParamsFactory.Create(_ => { });
        var result = OperationService.DoOperation(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Func_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(_ => { });

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Method_WithoutFinishOperation_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperation(DoWithoutFinishOperation);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public void DoOperation_SimpleOperationParam_WithoutParameters_WithLog_Test()
    {
        var param = ParamsFactory.CreateSimple(() => { });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_SimpleFunc_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(() => { }, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_SimpleMethod_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(DoWithoutOperationResult, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_OperationParam_WithoutParameters_WithLog_Test()
    {
        var param = ParamsFactory.Create(result =>
        {
            result.Done();
        });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(param, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Func_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(result =>
        {
            result.Done();
        }, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Method_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(Do, logParam, false);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public void DoOperation_OperationParam_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var param = ParamsFactory.Create(_ => { });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Func_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(_ => { }, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_Method_WithoutFinishOperation_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperation(DoWithoutFinishOperation, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion
    
    private const string Result = "Test";

    #region DoOperationWithResultAsync
    [Fact]
    public async Task DoOperationWithResultAsync_SimpleOperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(() => Task.FromResult(Result)!);
        var result = await OperationService.DoOperationWithResultAsync(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_SimpleFunc_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationWithResultAsync(() => Task.FromResult(Result)!);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_SimpleMethod_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationWithResultAsync(DoWithResultWithoutOperationResultAsync!);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_OperationParam_WithoutParameters_WithoutLog_Test()
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
    public async Task DoOperationWithResultAsync_Func_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationWithResultAsync<string>(result =>
        {
            result.Done(Result);
            return Task.CompletedTask;
        });

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_Method_WithoutParameters_WithoutLog_Test()
    {
        var result = await OperationService.DoOperationWithResultAsync<string>(DoWithResultAsync);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_SimpleOperationParam_WithoutParameters_WithLog_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(() => Task.FromResult(Result)!);
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_SimpleFunc_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync(() => Task.FromResult(Result)!, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_SimpleMethod_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync(DoWithResultWithoutOperationResultAsync!, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_OperationParam_WithoutParameters_WithLog_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<string>(result =>
        {
            result.Done(Result);
            return Task.CompletedTask;
        });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_Func_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync<string>(result =>
        {
            result.Done(Result);
            return Task.CompletedTask;
        }, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationWithResultAsync_Method_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = await OperationService.DoOperationWithResultAsync<string>(DoWithResultAsync, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion

    #region DoOperationWithResult
    [Fact]
    public void DoOperationWithResult_SimpleOperationParam_WithoutParameters_WithoutLog_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult(() => Result);
        var result = OperationService.DoOperationWithResult(param);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_SimpleFunc_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperationWithResult(() => Result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_SimpleMethod_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperationWithResult(DoWithResultWithoutOperationResult);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_OperationParam_WithoutParameters_WithoutLog_Test()
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
    public void DoOperationWithResult_Func_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperationWithResult<string>(result =>
        {
            result.Done(Result);
        });

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_Method_WithoutParameters_WithoutLog_Test()
    {
        var result = OperationService.DoOperationWithResult<string>(DoWithResult);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public void DoOperationWithResult_SimpleOperationParam_WithoutParameters_WithLog_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult(() => Result);
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_SimpleFunc_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult(() => Result, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_SimpleMethod_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult(DoWithResultWithoutOperationResult, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_OperationParam_WithoutParameters_WithLog_Test()
    {
        var param = ParamsFactory.CreateWithResult<string>(result =>
        {
            result.Done(Result);
        });
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult(param, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_Func_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult<string>(result =>
        {
            result.Done(Result);
        }, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperationWithResult_Method_WithoutParameters_WithLog_Test()
    {
        var logParam = LogParamsFactory.Create(LogError);
        
        var result = OperationService.DoOperationWithResult<string>(DoWithResult, logParam);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion
    
    private static Task DoWithoutOperationResultAsync()
    {
        return Task.CompletedTask;
    }

    private static Task DoAsync(IOperationResult result)
    {
        result.Done();
        return Task.CompletedTask;
    }

    private static Task DoWithoutFinishOperationAsync(IOperationResult result)
    {
        return Task.CompletedTask;
    }

    private static void DoWithoutOperationResult()
    {
    }

    private static void Do(IOperationResult result)
    {
        result.Done();
    }

    private static void DoWithoutFinishOperation(IOperationResult result)
    {
    }
    
    private static Task<string> DoWithResultWithoutOperationResultAsync()
    {
        return Task.FromResult(Result);
    }

    private static Task DoWithResultAsync(IOperationResult<string> result)
    {
        result.Done(Result);
        return Task.CompletedTask;
    }

    private static string DoWithResultWithoutOperationResult()
    {
        return Result;
    }

    private static void DoWithResult(IOperationResult<string> result)
    {
        result.Done(Result);
    }

    private static void LogError(string error)
    {
    }
}