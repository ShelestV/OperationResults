namespace OperationResults.Tests.ExtensionTests;

public sealed class ToGenericTests
{
	private const string SuccessStringResult = "Success";
	private const int SuccessIntResult = 1;

	private readonly Exception exception = new("Test exception");

	private IOperationResult result = new OperationResult();

	private void Reset()
	{
		this.result = new OperationResult();
	}

	[Fact]
	public void OkResult_ToGeneric_Reference_Test()
	{
		this.Reset();

		this.result.Done();

		var gResult = result.ToGeneric(SuccessStringResult);

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.Ok);
		gResult.Result.Should().Be(SuccessStringResult);
	}

	[Fact]
	public void OkResult_ToGeneric_Value_Test()
	{
		this.Reset();

		this.result.Done();

		var gResult = result.ToGeneric(SuccessIntResult);

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.Ok);
		gResult.Result.Should().Be(SuccessIntResult);
	}

	[Fact]
	public void OkResult_ToGeneric_WithNullReferenceResult_Test()
	{
		this.Reset();

		this.result.Done();

		var gResult = result.ToGeneric<string>(null);

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.BadFlow);
		gResult.Exception.Should().BeOfType<ArgumentException>();
	}

	[Fact]
	public void OkResult_ToGeneric_WithNullValueResult_Test()
	{
		this.Reset();

		this.result.Done();

		var gResult = result.ToGeneric<int>(default);

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.BadFlow);
		gResult.Exception.Should().BeOfType<ArgumentException>();
	}

	[Fact]
	public void BadFlowResult_ToGeneric_Test()
	{
		this.Reset();

		this.result.Fail(this.exception);

		var gResult = this.result.ToGeneric<string>();

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.BadFlow);
		gResult.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void NotFoundResult_ToGeneric_Test()
	{
		this.Reset();

		this.result.NotFound();

		var gResult = this.result.ToGeneric<string>();

		using var _ = new AssertionScope();
		gResult.State.Should().Be(OperationResultState.NotFound);
	}

	[Fact]
	public void OperationStillProcessingResult_ToGeneric_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.result.Invoking(x => x.ToGeneric<string>()).Should().Throw<OperationStillProcessingException>();
	}
}
