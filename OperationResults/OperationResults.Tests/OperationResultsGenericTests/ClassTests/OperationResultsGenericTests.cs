namespace OperationResults.Tests._OperationResultsGenericTests.ClassTests;

public class OperationResultsGenericTests
{
    private IOperationResult<string> result = OperationResultFactory.Create<string>();

    private void ResetResult()
    {
        result = OperationResultFactory.Create<string>();
    }

    [Fact]
    public void DefaultBehaviour_Success_Test()
    {
        this.ResetResult();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Processing);
        this.result.Invoking(x => x.Result).Should().Throw<OperationStillProcessingException>();
        this.result.Invoking(x => x.Exception).Should().Throw<OperationStillProcessingException>();
    }

    [Fact]
    public void DoneOperationResult_Success_Test()
    {
        this.ResetResult();

        var str = string.Empty;

        this.result.Done(str);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Ok);
        this.result.Invoking(x => x.Result).Should().NotThrow();
        this.result.Result.Should().Be(str);
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void FailOperationResult_Success_Test()
    {
        this.ResetResult();

        var ex = new Exception("Test");

        this.result.Fail(ex);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Invoking(x => x.Exception).Should().NotThrow();
        this.result.Exception.Should().Be(ex);
        this.result.Invoking(x => x.Result).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void NotFoundOperationResult_Success_Test()
    {
        this.ResetResult();

        this.result.NotFound();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
        this.result.Invoking(x => x.Result).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void FailOperationResult_NullException_Test()
    {
        this.ResetResult();

        this.result.Fail(null);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Invoking(x => x.Exception).Should().Throw<OperationExceptionNullException>();
        this.result.Invoking(x => x.Result).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void DoneOperationResult_NullResult_Test()
    {
        this.ResetResult();

        this.result.Done(null);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Ok);
        this.result.Invoking(x => x.Result).Should().Throw<OperationResultNullException>();
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void DoneOperationResult_TryChangeStateFromFailToDone_WhenItIsImpossible()
    {
        this.ResetResult();
        
        this.result.Fail(new Exception("Test"));

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().Be(OperationResultState.BadFlow);
        }
        
        this.result.Done("Test");

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().NotBe(OperationResultState.Ok);
            this.result.State.Should().Be(OperationResultState.BadFlow);
        }
    }
}
