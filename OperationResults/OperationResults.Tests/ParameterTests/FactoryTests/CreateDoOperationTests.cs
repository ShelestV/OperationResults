using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateDoOperationTests
{
	private const int Value1 = 1;
	private const string Value2 = "value";
	private const double Value3 = 15.5;

	private IOperationResult result = new OperationResult();

	private void Reset()
	{
		this.result = new OperationResult();
	}

	[Fact]
	public void Create_DoOperation_0Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.Create(DoOperation);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void Create_DoOperation_1Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.Create(DoOperation, Value1);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void Create_DoOperation_2Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.Create(DoOperation, Value1, Value2);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void Create_DoOperation_3Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.Create(DoOperation, Value1, Value2, Value3);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
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
