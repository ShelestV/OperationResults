using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ServicesTests.ParametersTests;

public class DoOperationParamTests
{
    private const string Value1 = "Test";
    private const int Value2 = 1;
    private const double Value3 = 15.5;

    #region DoSimpleOperation
    [Fact]
    public void DoSimpleOperation_ZeroParameters_Test()
    {
        var param = ParamsFactory.CreateSimple(() =>
        {
            using var _ = new AssertionScope();
            1.Should().Be(1);
        });
        
        param.Invoke();
    }

    [Fact]
    public void DoSimpleOperation_OneParameter_Test()
    {
        var param = ParamsFactory.CreateSimple(value1 =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
        }, Value1);
        
        param.Invoke();
    }
    
    [Fact]
    public void DoSimpleOperation_TwoParameters_Test()
    {
        var param = ParamsFactory.CreateSimple((value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
        }, Value1, Value2);
        
        param.Invoke();
    }

    [Fact]
    public void DoSimpleOperation_ThreeParameter_Test()
    {
        var param = ParamsFactory.CreateSimple((value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
        }, Value1, Value2, Value3);
        
        param.Invoke();
    }
    #endregion

    #region DoSimpleOperationAsync
    [Fact]
    public async Task DoSimpleOperationAsync_ZeroParameters_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(() =>
        {
            using var _ = new AssertionScope();
            1.Should().Be(1);
            return Task.CompletedTask;
        });
        
        await param.InvokeAsync();
    }

    [Fact]
    public async Task DoSimpleOperationAsync_OneParameter_Test()
    {
        var param = AsyncParamsFactory.CreateSimple(value1 =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            return Task.CompletedTask;
        }, Value1);
        
        await param.InvokeAsync();
    }
    
    [Fact]
    public async Task DoSimpleOperationAsync_TwoParameters_Test()
    {
        var param = AsyncParamsFactory.CreateSimple((value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            return Task.CompletedTask;
        }, Value1, Value2);
        
        await param.InvokeAsync();
    }

    [Fact]
    public async Task DoSimpleOperationAsync_ThreeParameter_Test()
    {
        var param = AsyncParamsFactory.CreateSimple((value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
            return Task.CompletedTask;
        }, Value1, Value2, Value3);
        
        await param.InvokeAsync();
    }
    #endregion

    #region DoOperation
    [Fact]
    public void DoOperation_ZeroParameters_Test()
    {
        var param = ParamsFactory.Create(result =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
            }

            result.Done();
        });

        var result = OperationResultFactory.Create();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_OneParameter_Test()
    {
        var param = ParamsFactory.Create((result, value1) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
            }

            result.Done();
        }, Value1);

        var result = OperationResultFactory.Create();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public void DoOperation_TwoParameters_Test()
    {
        var param = ParamsFactory.Create((result, value1, value2) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
            }

            result.Done();
        }, Value1, Value2);

        var result = OperationResultFactory.Create();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public void DoOperation_ThreeParameter_Test()
    {
        var param = ParamsFactory.Create((result, value1, value2, value3) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
                value3.Should().Be(Value3);
            }

            result.Done();
        }, Value1, Value2, Value3);

        var result = OperationResultFactory.Create();
        param.Invoke(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion

    #region DoOperationAsync
    [Fact]
    public async Task DoOperationAsync_ZeroParameters_Test()
    {
        var param = AsyncParamsFactory.Create(result =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
            }

            result.Done();

            return Task.CompletedTask;
        });

        var result = OperationResultFactory.Create();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_OneParameter_Test()
    {
        var param = AsyncParamsFactory.Create((result, value1) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
            }

            result.Done();

            return Task.CompletedTask;
        }, Value1);

        var result = OperationResultFactory.Create();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    
    [Fact]
    public async Task DoOperationAsync_TwoParameters_Test()
    {
        var param = AsyncParamsFactory.Create((result, value1, value2) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
            }

            result.Done();

            return Task.CompletedTask;
        }, Value1, Value2);

        var result = OperationResultFactory.Create();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }

    [Fact]
    public async Task DoOperationAsync_ThreeParameter_Test()
    {
        var param = AsyncParamsFactory.Create((result, value1, value2, value3) =>
        {
            using (var _ = new AssertionScope())
            {
                result.State.Should().Be(OperationResultState.Processing);
                value1.Should().Be(Value1);
                value2.Should().Be(Value2);
                value3.Should().Be(Value3);
            }

            result.Done();
            
            return Task.CompletedTask;
        }, Value1, Value2, Value3);

        var result = OperationResultFactory.Create();
        await param.InvokeAsync(result);

        using var _ = new AssertionScope();
        result.State.Should().Be(OperationResultState.Ok);
    }
    #endregion
}
