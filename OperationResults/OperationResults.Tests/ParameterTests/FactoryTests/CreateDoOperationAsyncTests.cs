using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateDoOperationAsyncTests
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
	public async Task Create_DoOperationAsync_0Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.Create(DoOperationAsync);

		await param.InvokeAsync(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task Create_DoOperationAsync_1Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.Create(DoOperationAsync, Value1);

		await param.InvokeAsync(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task Create_DoOperationAsync_2Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.Create(DoOperationAsync, Value1, Value2);

		await param.InvokeAsync(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task Create_DoOperationAsync_3Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.Create(DoOperationAsync, Value1, Value2, Value3);

		await param.InvokeAsync(result);

		result.State.Should().Be(OperationResultState.Ok);
	}

	private Task DoOperationAsync(IOperationResult result)
	{
		result.Done();

		return Task.CompletedTask;
	}

	private Task DoOperationAsync(IOperationResult result, int value1)
	{
		result.Done();

		value1.Should().Be(Value1);

		return Task.CompletedTask;
	}

	private Task DoOperationAsync(IOperationResult result, int value1, string value2)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);

		return Task.CompletedTask;
	}

	private Task DoOperationAsync(IOperationResult result, int value1, string value2, double value3)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);

		return Task.CompletedTask;
	}
}
