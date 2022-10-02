using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests;

public sealed class LogOperationWithSuffixTests
{
	private const string Suffix = "Suffix";

	private const int Value1 = 1;
	private const string Value2 = "old value";
	private const double Value3 = 15.5;

	[Fact]
	public void LogOperation_0param_Test()
	{
		var param = new LogOperationWithSuffixParam(LogOperation);

		param.Invoke(Suffix);
	}

	[Fact]
	public void LogOperation_1param_Test()
	{
		var param = new LogOperationWithSuffixParam<int>(LogOperation, Value1);

		param.Invoke(Suffix);
	}

	[Fact]
	public void LogOperation_2param_Test()
	{
		var param = new LogOperationWithSuffixParam<int, string>(LogOperation, Value1, Value2);

		param.Invoke(Suffix);
	}

	[Fact]
	public void LogOperation_3param_Test()
	{
		var param = new LogOperationWithSuffixParam<int, string, double>(LogOperation, Value1, Value2, Value3);

		param.Invoke(Suffix);
	}

	private static void LogOperation(string suffix)
	{
		suffix.Should().Be(Suffix);
	}

	private static void LogOperation(string suffix, int value1)
	{
		value1.Should().Be(Value1);

		suffix.Should().Be(Suffix);
	}

	private static void LogOperation(string suffix, int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);

		suffix.Should().Be(Suffix);
	}

	private static void LogOperation(string suffix, int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);

		suffix.Should().Be(Suffix);
	}
}
