using OperationResults.Services.Parameters.Generic;

namespace OperationResults.Tests.ParameterTests;

public sealed class DoOperationAsyncGenericParamTests
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
	public async Task DoOperationAsync_0param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<string>(DoOperationAsync);

		await param.InvokeAsync(this.result);
	}

	[Fact]
	public async Task DoOperationAsync_1param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<string, int>(DoOperationAsync, Value1);

		await param.InvokeAsync(this.result);
	}

	[Fact]
	public async Task DoOperationAsync_2param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<string, int, string>(DoOperationAsync, Value1, Value2);

		await param.InvokeAsync(this.result);
	}

	[Fact]
	public async Task DoOperationAsync_3param_Test()
	{
		this.Reset();

		var param = new DoOperationAsyncParam<string, int, string, double>(DoOperationAsync, Value1, Value2, Value3);

		await param.InvokeAsync(this.result);
	}

	private static Task<string> DoOperationAsync(IOperationResult<string> result)
	{
		return Task.FromResult(StringResult);
	}

	private static Task<string> DoOperationAsync(IOperationResult<string> result, int value1)
	{
		value1.Should().Be(Value1);

		return Task.FromResult(StringResult);
	}

	private static Task<string> DoOperationAsync(IOperationResult<string> result, int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);

		return Task.FromResult(StringResult);
	}

	private static Task<string> DoOperationAsync(IOperationResult<string> result, int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);

		return Task.FromResult(StringResult);
	}
}
