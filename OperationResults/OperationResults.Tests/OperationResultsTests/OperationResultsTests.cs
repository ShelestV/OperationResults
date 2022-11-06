namespace OperationResults.Tests._OperationResultsTests;

public class OperationResultsTests
{
    private IOperationResult result = OperationResultFactory.Create();

    private void ResetResult()
    {
        result = OperationResultFactory.Create();
    }

    [Fact]
    public void DefaultBehaviour_Success_Test()
    {
        this.ResetResult();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Processing);
        this.result.Invoking(x => x.Exception).Should().Throw<OperationStillProcessingException>();
    }

    [Fact]
    public void DoneOperationResult_Success_Test()
    {
        this.ResetResult();

        this.result.Done();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Ok);
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
    }

    [Fact]
    public void NotFoundOperationResult_Success_Test()
    {
        this.ResetResult();

        this.result.NotFound();

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.NotFound);
        this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
    }

    [Fact]
    public void FailOperationResult_NullException_Test()
    {
        this.ResetResult();

        this.result.Fail(null);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.BadFlow);
        this.result.Invoking(x => x.Exception).Should().Throw<OperationExceptionNullException>();
    }
    
    [Fact]
    public void DoneOperationResult_TryChangeStateFromDoneToNotFound_WhenItIsImpossible()
    {
        this.ResetResult();

        this.result.Done();
        
        using (var _ = new AssertionScope())
        {
            this.result.State.Should().Be(OperationResultState.Ok);
        }
        
        this.result.NotFound();

        using (var _ = new AssertionScope())
        {
            result.State.Should().NotBe(OperationResultState.NotFound);
            result.State.Should().Be(OperationResultState.Ok);
        }
    }

    [Fact]
    public void DoneOperationResult_TryChangeStateFromNotFoundToFail_WhenItIsImpossible()
    {
        this.ResetResult();
        
        this.result.NotFound();

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().Be(OperationResultState.NotFound);
        }
        
        this.result.Fail(new Exception("Test"));

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().NotBe(OperationResultState.BadFlow);
            this.result.State.Should().Be(OperationResultState.NotFound);
        }
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
        
        this.result.Done();

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().NotBe(OperationResultState.Ok);
            this.result.State.Should().Be(OperationResultState.BadFlow);
        }
    }
}
