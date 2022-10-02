namespace OperationResults.Tests.ExtensionTests;

public sealed class ToGeneralTests
{
	private const string SuccessStringResult = "Success";
	private const int SuccessIntResult = 1;

	private readonly Exception exception = new("Test exception");

	private IOperationResult<string> stringResult = new OperationResult<string>();
	private IOperationResult<int> intResult = new OperationResult<int>();

	private void Reset()
	{
		this.stringResult = new OperationResult<string>();
		this.intResult = new OperationResult<int>();
	}

	[Fact]
	public void OkResult_Reference_ToGeneral_Test()
	{
		this.Reset();

		this.stringResult.Done(SuccessStringResult);

		var result = this.stringResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void OkResult_Value_ToGeneral_Test()
	{
		this.Reset();

		this.intResult.Done(SuccessIntResult);

		var result = intResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void BadFlowResult_Reference_ToGeneral_Test()
	{
		this.Reset();

		this.stringResult.Fail(this.exception);

		var result = this.stringResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void BadFlowResult_Value_ToGeneral_Test()
	{
		this.Reset();

		this.intResult.Fail(this.exception);

		var result = this.intResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void NotFoundResult_Reference_ToGeneral_Test()
	{
		this.Reset();

		this.stringResult.NotFound();

		var result = this.stringResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.NotFound);
	}

	[Fact]
	public void NotFoundResult_Value_ToGeneral_Test()
	{
		this.Reset();

		this.intResult.NotFound();

		var result = this.intResult.ToGeneral();

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.NotFound);
	}

	[Fact]
	public void OperationStillProcessingResult_Reference_ToGeneral_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.stringResult.Invoking(x => x.ToGeneral()).Should().Throw<OperationStillProcessingException>();
	}

	[Fact]
	public void OperationStillProcessingResult_Value_ToGeneral_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.intResult.Invoking(x => x.ToGeneral()).Should().Throw<OperationStillProcessingException>();
	}
}
