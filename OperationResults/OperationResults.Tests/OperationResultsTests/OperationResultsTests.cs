namespace OperationResults.Tests._OperationResultsTests;

public class OperationResultsTests
{
    private IOperationResult result = OperationResultFactory.Create();

    private void ReserResult()
    {
        result = OperationResultFactory.Create();
    }

    [Fact]
    public void DefaultBehaviour_Success_Test()
    {
        this.ReserResult();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Processing);
        this.result.Invoking(x => x.Exception).Should().Throw<OperationStillProcessingException>();
    }

    [Fact]
    public void DoneOperationResult_Success_Test()
    {
        this.ReserResult();

        this.result.Done();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Ok);
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void FailOperationResult_Success_Test()
    {
        this.ReserResult();

        var ex = new Exception("Test");

        this.result.Fail(ex);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Invoking(x => x.Exception).Should().NotThrow();
        this.result.Exception.Should().Be(ex);
    }

    [Fact]
    public void NotFoundOperationResult_Success_Test()
    {
        this.ReserResult();

        this.result.NotFound();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void FailOperationResult_NullException_Test()
    {
        this.ReserResult();

        this.result.Fail(null);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Invoking(x => x.Exception).Should().Throw<OperationExceptionNullException>();
    }
}
