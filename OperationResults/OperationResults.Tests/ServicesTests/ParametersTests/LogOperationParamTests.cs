using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ServicesTests.ParametersTests;

public class LogOperationParamTests
{
    private const string Suffix = "Suffix";
    
    private const string Value1 = "Test";
    private const int Value2 = 1;
    private const double Value3 = 15.5;
    
    [Fact]
    public void CreateLog_ZeroParameter_Test()
    {
        var param = LogParamsFactory.Create(() =>
        {
            using var _ = new AssertionScope();
            1.Should().Be(1);
        });
        
        param.Invoke();
    }
    
    [Fact]
    public void CreateLog_OneParameter_Test()
    {
        var param = LogParamsFactory.Create(value1 =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
        }, Value1);
        
        param.Invoke();
    }

    [Fact]
    public void CreateLog_TwoParameters_Test()
    {
        var param = LogParamsFactory.Create((value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
        }, Value1, Value2);
        
        param.Invoke();
    }
    
    [Fact]
    public void CreateLog_ThreeParameters_Test()
    {
        var param = LogParamsFactory.Create((value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
        }, Value1, Value2, Value3);
        
        param.Invoke();
    }
    
    [Fact]
    public void CreateLogWithSuffix_ZeroParameter_Test()
    {
        var param = LogParamsFactory.Create(message =>
        {
            using var _ = new AssertionScope();
            message.Should().Be(Suffix);
        });
        
        param.Invoke(Suffix);
    }
    
    [Fact]
    public void CreateLogWithSuffix_OneParameter_Test()
    {
        var param = LogParamsFactory.Create((message, value1) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            message.Should().Be(Suffix);
        }, Value1);
        
        param.Invoke(Suffix);
    }

    [Fact]
    public void CreateLogWithSuffix_TwoParameters_Test()
    {
        var param = LogParamsFactory.Create((message, value1, value2) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            message.Should().Be(Suffix);
        }, Value1, Value2);
        
        param.Invoke(Suffix);
    }
    
    [Fact]
    public void CreateLogWithSuffix_ThreeParameters_Test()
    {
        var param = LogParamsFactory.Create((message, value1, value2, value3) =>
        {
            using var _ = new AssertionScope();
            value1.Should().Be(Value1);
            value2.Should().Be(Value2);
            value3.Should().Be(Value3);
            message.Should().Be(Suffix);
        }, Value1, Value2, Value3);
        
        param.Invoke(Suffix);
    }
}