using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateLogOperationTests
{
	private const int Value1 = 1;
	private const string Value2 = "value";
	private const double Value3 = 15.5;

	[Fact]
	public void Create_LogOperation_0Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation);

		param.Invoke();
	}

	[Fact]
	public void Create_LogOperation_1Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1);

		param.Invoke();
	}

	[Fact]
	public void Create_LogOperation_2Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1, Value2);

		param.Invoke();
	}

	[Fact]
	public void Create_LogOperation_3Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1, Value2, Value3);

		param.Invoke();
	}

	private void LogOperation()
	{
	}

	private void LogOperation(int value1)
	{
		value1.Should().Be(Value1);
	}

	private void LogOperation(int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
	}

	private void LogOperation(int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
	}
}
