using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateDoOperationGenericTests
{
	private const int SuccessResult = 1;

	private const int Value1 = 1;
	private const string Value2 = "value";
	private const double Value3 = 15.5;

	private IOperationResult<int> result = new OperationResult<int>();

	private void Reset()
	{
		this.result = new OperationResult<int>();
	}

	[Fact]
	public void Create_DoOperation_0Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.CreateWithResult<int>(DoOperation);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(SuccessResult);
	}

	[Fact]
	public void Create_DoOperation_1Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.CreateWithResult<int, int>(DoOperation, Value1);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(SuccessResult);
	}

	[Fact]
	public void Create_DoOperation_2Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.CreateWithResult<int, int, string>(DoOperation, Value1, Value2);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(SuccessResult);
	}

	[Fact]
	public void Create_DoOperation_3Param_Success_Test()
	{
		this.Reset();

		var param = ParamsFactory.CreateWithResult<int, int, string, double>(DoOperation, Value1, Value2, Value3);

		param.Invoke(result);

		result.State.Should().Be(OperationResultState.Ok);
		result.Result.Should().Be(SuccessResult);
	}

	private void DoOperation(IOperationResult<int> result)
	{
		result.Done(SuccessResult);
	}

	private void DoOperation(IOperationResult<int> result, int value1)
	{
		result.Done(SuccessResult);

		value1.Should().Be(Value1);
	}

	private void DoOperation(IOperationResult<int> result, int value1, string value2)
	{
		result.Done(SuccessResult);

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
	}

	private void DoOperation(IOperationResult<int> result, int value1, string value2, double value3)
	{
		result.Done(SuccessResult);

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);
	}
}
