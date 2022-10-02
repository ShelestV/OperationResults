using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests;

public sealed class LogOperationParamTests
{
	private const int Value1 = 1;
	private const string Value2 = "old value";
	private const double Value3 = 15.5;

	[Fact]
	public void LogOperation_0param_Test()
	{
		var param = new LogOperationParam(LogOperation);

		param.Invoke();
	}

	[Fact]
	public void LogOperation_1param_Test()
	{
		var param = new LogOperationParam<int>(LogOperation, Value1);

		param.Invoke();
	}

	[Fact]
	public void LogOperation_2param_Test()
	{
		var param = new LogOperationParam<int, string>(LogOperation, Value1, Value2);

		param.Invoke();
	}

	[Fact]
	public void LogOperation_3param_Test()
	{
		var param = new LogOperationParam<int, string, double>(LogOperation, Value1, Value2, Value3);

		param.Invoke();
	}

	private static void LogOperation()
	{
	}

	private static void LogOperation(int value1)
	{
		value1.Should().Be(Value1);
	}

	private static void LogOperation(int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
	}

	private static void LogOperation(int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
	}
}
