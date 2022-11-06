using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ServicesTests.ParametersTests;

public class DoOperationGenericParamTests
{
    private readonly Guid testResult = Guid.NewGuid();
    
    private const string Value1 = "Test";
    private const int Value2 = 1;
    private const double Value3 = 15.5;

    #region DoSimpleOperation
    [Fact]
    public void DoSimpleOperation_ZeroParameters_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult(() => this.testResult);
        
        var result = param.Invoke();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }

    [Fact]
    public void DoSimpleOperation_OneParameter_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult(value1 =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            return this.testResult;
        }, Value1);
        
        var result = param.Invoke();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }
    
    [Fact]
    public void DoSimpleOperation_TwoParameters_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult((value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            return this.testResult;
        }, Value1, Value2);
        
        var result = param.Invoke();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }

    [Fact]
    public void DoSimpleOperation_ThreeParameter_Test()
    {
        var param = ParamsFactory.CreateSimpleWithResult((value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
            return this.testResult;
        }, Value1, Value2, Value3);
        
        var result = param.Invoke();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }
    #endregion

    #region DoSimpleOperationAsync
    [Fact]
    public async Task DoSimpleOperationAsync_ZeroParameters_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(() => Task.FromResult(this.testResult));
        
        var result = await param.InvokeAsync();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }

    [Fact]
    public async Task DoSimpleOperationAsync_OneParameter_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult(value1 =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            return Task.FromResult(this.testResult);
        }, Value1);
        
        var result = await param.InvokeAsync();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }
    
    [Fact]
    public async Task DoSimpleOperationAsync_TwoParameters_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult((value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            return Task.FromResult(this.testResult);
        }, Value1, Value2);
        
        var result = await param.InvokeAsync();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }

    [Fact]
    public async Task DoSimpleOperationAsync_ThreeParameter_Test()
    {
        var param = AsyncParamsFactory.CreateSimpleWithResult((value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
            return Task.FromResult(this.testResult);
        }, Value1, Value2, Value3);
        
        var result = await param.InvokeAsync();

        using var _ = new AssertionScope();
        result.Should().Be(this.testResult);
    }
    #endregion

    #region DoOperation
    [Fact]
    public void DoOperation_ZeroParameters_Test()
    {
        var param = ParamsFactory.CreateWithResult<Guid>(result =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
            }

            result.Done(this.testResult);
        });

        var result = OperationResultFactory.Create<Guid>();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }

    [Fact]
    public void DoOperation_OneParameter_Test()
    {
        var param = ParamsFactory.CreateWithResult<Guid, string>((result, value1) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
            }
            
            result.Done(this.testResult);
        }, Value1);

        var result = OperationResultFactory.Create<Guid>();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }
    
    [Fact]
    public void DoOperation_TwoParameters_Test()
    {
        var param = ParamsFactory.CreateWithResult<Guid, string, int>((result, value1, value2) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
            }

            result.Done(this.testResult);
        }, Value1, Value2);

        var result = OperationResultFactory.Create<Guid>();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }

    [Fact]
    public void DoOperation_ThreeParameter_Test()
    {
        var param = ParamsFactory.CreateWithResult<Guid, string, int, double>((result, value1, value2, value3) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
                value3.Should().Be(Value3);
            }

            result.Done(this.testResult);
        }, Value1, Value2, Value3);

        var result = OperationResultFactory.Create<Guid>();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }
    #endregion

    #region DoOperationAsync
    [Fact]
    public async Task DoOperationAsync_ZeroParameters_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<Guid>(result =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
            }

            result.Done(this.testResult);
            
            return Task.CompletedTask;
        });

        var result = OperationResultFactory.Create<Guid>();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }

    [Fact]
    public async Task DoOperationAsync_OneParameter_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<Guid, string>((result, value1) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
            }
            
            result.Done(this.testResult);

            return Task.CompletedTask;
        }, Value1);

        var result = OperationResultFactory.Create<Guid>();
        await param.InvokeAsync(result);
    }
    
    [Fact]
    public async Task DoOperationAsync_TwoParameters_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<Guid, string, int>((result, value1, value2) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
            }
            
            result.Done(this.testResult);

            return Task.CompletedTask;
        }, Value1, Value2);

        var result = OperationResultFactory.Create<Guid>();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }

    [Fact]
    public async Task DoOperationAsync_ThreeParameter_Test()
    {
        var param = AsyncParamsFactory.CreateWithResult<Guid, string, int, double>((result, value1, value2, value3) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
                value3.Should().Be(Value3);
            }
            
            result.Done(this.testResult);

            return Task.CompletedTask;
        }, Value1, Value2, Value3);

        var result = OperationResultFactory.Create<Guid>();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
        result.Result.Should().Be(this.testResult);
    }
    #endregion
}