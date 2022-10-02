namespace OperationResults.Tests.ExtensionTests;

public class ChangeTypeTests
{
	private IOperationResult<string> stringResult = new OperationResult<string>();
	private IOperationResult<int> intResult = new OperationResult<int>();

	private readonly Exception exception = new("Test");
	private const string SuccessStringResult = "Success";
	private const int SuccessIntResult = 1;

	private void Reset()
	{
		this.stringResult = new OperationResult<string>();
		this.intResult = new OperationResult<int>();
	}

	[Fact]
	public void OkResult_Reference_ChangeTypeToValue_Test()
	{
		this.Reset();

		this.stringResult.Done(SuccessStringResult);

		var result = this.stringResult.ChangeResultType(SuccessIntResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void OkResult_Value_ChangeTypeToReference_Test()
	{
		this.Reset();

		this.intResult.Done(SuccessIntResult);

		var result = intResult.ChangeResultType(SuccessStringResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.Ok);
	}

	[Fact]
	public void BadFlowResult_Reference_ChangeTypeToValue_Test()
	{
		this.Reset();

		this.stringResult.Fail(this.exception);

		var result = this.stringResult.ChangeResultType(SuccessIntResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void BadFlowResult_Value_ChangeTypeToReference_Test()
	{
		this.Reset();

		this.intResult.Fail(this.exception);

		var result = this.intResult.ChangeResultType(SuccessStringResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.BadFlow);
		result.Exception.Should().Be(this.exception);
	}

	[Fact]
	public void NotFoundResult_Reference_ChangeTypeToValue_Test()
	{
		this.Reset();

		this.stringResult.NotFound();

		var result = this.stringResult.ChangeResultType(SuccessIntResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.NotFound);
	}

	[Fact]
	public void NotFoundResult_Value_ChangeTypeToReference_Test()
	{
		this.Reset();

		this.intResult.NotFound();

		var result = this.intResult.ChangeResultType(SuccessStringResult);

		using var _ = new AssertionScope();
		result.State.Should().Be(OperationResultState.NotFound);
	}

	[Fact]
	public void OperationStillProcessingResult_Reference_ChangeTypeToValue_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.stringResult.Invoking(x => x.ChangeResultType(SuccessIntResult)).Should().Throw<OperationStillProcessingException>();
	}

	[Fact]
	public void OperationStillProcessingResult_Value_ChangeTypeToString_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.intResult.Invoking(x => x.ChangeResultType(SuccessStringResult)).Should().Throw<OperationStillProcessingException>();
	}
}
