using OperationResults.Services.Parameters;

namespace OperationResults.Tests.ParameterTests.FactoryTests;

public sealed class CreateDoOperationAsyncGenericTests
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
	public async Task Create_DoOperationAsync_0Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.CreateWithResult<int>(DoOperationAsync);

		await param.InvokeAsync(result);
	}

	[Fact]
	public async Task Create_DoOperationAsync_1Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.CreateWithResult<int, int>(DoOperationAsync, Value1);
		
		await param.InvokeAsync(result);
	}

	[Fact]
	public async Task Create_DoOperationAsync_2Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.CreateWithResult<int, int, string>(DoOperationAsync, Value1, Value2);

		await param.InvokeAsync(result);
	}

	[Fact]
	public async Task Create_DoOperationAsync_3Param_Success_Test()
	{
		this.Reset();

		var param = AsyncParamsFactory.CreateWithResult<int, int, string, double>(DoOperationAsync, Value1, Value2, Value3);

		await param.InvokeAsync(result);
	}

	private static Task<int> DoOperationAsync(IOperationResult<int> result)
	{
		return Task.FromResult(SuccessResult);
	}

	private static Task<int> DoOperationAsync(IOperationResult<int> result, int value1)
	{
		value1.Should().Be(Value1);

		return Task.FromResult(SuccessResult);
	}

	private static Task<int> DoOperationAsync(IOperationResult<int> result, int value1, string value2)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);

		return Task.FromResult(SuccessResult);
	}

	private static Task<int> DoOperationAsync(IOperationResult<int> result, int value1, string value2, double value3)
	{
		value1.Should().Be(Value1);
		value2.Should().Be(Value2);
		value3.Should().Be(Value3);

		return Task.FromResult(SuccessResult);
	}
}
