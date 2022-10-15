using OperationResults.Services.Parameters.Generic;

namespace OperationResults.Tests.ParameterTests;

public sealed class DoOperationGenericParamTests
{
	private IOperationResult<string> result = new OperationResult<string>();

	private const string StringResult = "Success";

	private const int Value1 = 1;
	private const string Value2 = "old value";
	private const double Value3 = 15.5;

	private void Reset()
	{
		this.result = new OperationResult<string>();
	}

	[Fact]
	public void DoOperation_0param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<string>(DoOperation);

		param.Invoke(this.result);
	}

	[Fact]
	public void DoOperation_1param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<string, int>(DoOperation, Value1);

		param.Invoke(this.result);
	}

	[Fact]
	public void DoOperation_2param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<string, int, string>(DoOperation, Value1, Value2);

		param.Invoke(this.result);
	}

	[Fact]
	public void DoOperation_3param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<string, int, string, double>(DoOperation, Value1, Value2, Value3);

		param.Invoke(this.result);
	}

	private static string DoOperation(IOperationResult<string> result)
	{
		return StringResult;
	}

	private static string DoOperation(IOperationResult<string> result, int value1)
	{
		value1.Should().Be(Value1);
		return StringResult;
	}

	private static string DoOperation(IOperationResult<string> result, int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		return StringResult;
	}

	private static string DoOperation(IOperationResult<string> result, int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
		return StringResult;
	}
}
