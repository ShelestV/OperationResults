using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests;

public sealed class DoOperationParamTests
{
	private IOperationResult result = new OperationResult();

	private const int Value1 = 1;
	private const string Value2 = "old value";
	private const double Value3 = 15.5;

	private void Reset()
	{
		this.result = new OperationResult();
	}

	[Fact]
	public void DoOperation_0param_Test()
	{
		this.Reset();

		var param = new DoOperationParam(DoOperation);

		param.Invoke(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void DoOperation_1param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<int>(DoOperation, Value1);

		param.Invoke(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void DoOperation_2param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<int, string>(DoOperation, Value1, Value2);

		param.Invoke(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void DoOperation_3param_Test()
	{
		this.Reset();

		var param = new DoOperationParam<int, string, double>(DoOperation, Value1, Value2, Value3);

		param.Invoke(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	private static void DoOperation(IOperationResult result)
	{
		result.Done();
	}

	private static void DoOperation(IOperationResult result, int value1)
	{
		result.Done();

		value1.Should().Be(Value1);
	}

	private static void DoOperation(IOperationResult result, int value1, string value2)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
	}

	private static void DoOperation(IOperationResult result, int value1, string value2, double value3)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
	}
}
