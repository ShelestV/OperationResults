namespace OperationResults.Tests.ExtensionTests;

public sealed class IsCorrectTests
{
	private IOperationResult result = new OperationResult();
	private IOperationResult<string> stringResult = new OperationResult<string>();
	private IOperationResult<int> intResult = new OperationResult<int>();

	private readonly Exception exception = new("Test");
	private const string SuccessStringResult = "Success";
	private const int SuccessIntResult = 1;

	private void Reset()
	{
		this.result = new OperationResult();
		this.stringResult = new OperationResult<string>();
		this.intResult = new OperationResult<int>();
	}

	[Fact]
	public void OkOperationResult_IsCorrect_Test()
	{
		this.Reset();

		this.result.Done();

		using var _ = new AssertionScope();
		this.result.IsCorrect().Should().BeTrue();
	}

	[Fact]
	public void NotFoundOperationResult_IsCorrect_Test()
	{
		this.Reset();

		this.result.NotFound();

		using var _ = new AssertionScope();
		this.result.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void BadFlowOperationResult_IsCorrect_Test()
	{
		this.Reset();

		this.result.Fail(this.exception);

		using var _ = new AssertionScope();
		this.result.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void OperationStillProcessingResult_IsCorrect_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.result.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void OkOperationResult_Reference_IsCorrect_Test()
	{
		this.Reset();

		this.stringResult.Done(SuccessStringResult);

		using var _ = new AssertionScope();
		this.stringResult.IsCorrect().Should().BeTrue();
	}

	[Fact]
	public void NotFoundOperationResult_Reference_IsCorrect_Test()
	{
		this.Reset();

		this.stringResult.NotFound();

		using var _ = new AssertionScope();
		this.stringResult.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void BadFlowOperationResult_Reference_IsCorrect_Test()
	{
		this.Reset();

		this.stringResult.Fail(this.exception);

		using var _ = new AssertionScope();
		this.stringResult.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void OperationStillProcessingResult_Reference_IsCorrect_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.stringResult.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void OkOperationResult_Value_IsCorrect_Test()
	{
		this.Reset();

		this.intResult.Done(SuccessIntResult);

		using var _ = new AssertionScope();
		this.intResult.IsCorrect().Should().BeTrue();
	}

	[Fact]
	public void NotFoundOperationResult_Value_IsCorrect_Test()
	{
		this.Reset();

		this.intResult.NotFound();

		using var _ = new AssertionScope();
		this.intResult.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void BadFlowOperationResult_Value_IsCorrect_Test()
	{
		this.Reset();

		this.intResult.Fail(this.exception);

		using var _ = new AssertionScope();
		this.intResult.IsCorrect().Should().BeFalse();
	}

	[Fact]
	public void OperationStillProcessingResult_Value_IsCorrect_Test()
	{
		this.Reset();

		using var _ = new AssertionScope();
		this.intResult.IsCorrect().Should().BeFalse();
	}
}
