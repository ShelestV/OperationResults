using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests;

public sealed class DoOperationAsyncParamTests
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
	public async Task DoOperationAsync_0param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam(DoOperationAsync);

		await param.InvokeAsync(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task DoOperationAsync_1param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<int>(DoOperationAsync, Value1);

		await param.InvokeAsync(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task DoOperationAsync_2param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<int, string>(DoOperationAsync, Value1, Value2);

		await param.InvokeAsync(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public async Task DoOperationAsync_3param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<int, string, double>(DoOperationAsync, Value1, Value2, Value3);

		await param.InvokeAsync(this.result);

		this.result.State.Should().Be(OperationResultState.Ok);
	}

	private static Task DoOperationAsync(IOperationResult result)
	{
		result.Done();

		return Task.CompletedTask;
	}

	private static Task DoOperationAsync(IOperationResult result, int value1)
	{
		result.Done();

		value1.Should().Be(Value1);

		return Task.CompletedTask;
	}

	private static Task DoOperationAsync(IOperationResult result, int value1, string value2)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);

		return Task.CompletedTask;
	}

	private static Task DoOperationAsync(IOperationResult result, int value1, string value2, double value3)
	{
		result.Done();

		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);

		return Task.CompletedTask;
	}
}
