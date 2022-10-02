using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateLogWithSuffixOperationTests
{
	private const string Suffix = "Suffix";

	private const int Value1 = 1;
	private const string Value2 = "value";
	private const double Value3 = 15.5;

	[Fact]
	public void Create_LogOperation_0Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation);

		param.Invoke(Suffix);
	}

	[Fact]
	public void Create_LogOperation_1Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1);

		param.Invoke(Suffix);
	}

	[Fact]
	public void Create_LogOperation_2Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1, Value2);

		param.Invoke(Suffix);
	}

	[Fact]
	public void Create_LogOperation_3Param_Success_Test()
	{
		var param = LogParamsFactory.Create(LogOperation, Value1, Value2, Value3);

		param.Invoke(Suffix);
	}

	private void LogOperation(string suffix)
	{
		suffix.Should().Be(Suffix);
	}

	private void LogOperation(string suffix, int value1)
	{
		suffix.Should().Be(Suffix);

		value1.Should().Be(Value1);
	}

	private void LogOperation(string suffix, int value1, string value2)
	{
		suffix.Should().Be(Suffix);

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
	}

	private void LogOperation(string suffix, int value1, string value2, double value3)
	{
		suffix.Should().Be(Suffix);

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
	}
}
