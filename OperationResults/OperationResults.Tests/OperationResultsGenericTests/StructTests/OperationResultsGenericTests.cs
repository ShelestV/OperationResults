namespace OperationResults.Tests._OperationResultsGenericTests.StructTests;

public class OperationResultsGenericTests
{
    private IOperationResult<Guid> result = OperationResultFactory.Create<Guid>();

    private void ResetResult()
    {
        result = OperationResultFactory.Create<Guid>();
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

        var guid = Guid.Empty;

        this.result.Done(guid);

        using var _ = new AssertionScope();
        this.result.State.Should().Be(OperationResultState.Ok);
        this.result.Invoking(x => x.Result).Should().NotThrow();
        this.result.Result.Should().Be(guid);
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
    public void DoneOperationResult_TryChangeStateFromFailToDone_WhenItIsImpossible()
    {
        this.ResetResult();
        
        this.result.Fail(new Exception("Test"));

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().Be(OperationResultState.BadFlow);
        }
        
        this.result.Done(Guid.NewGuid());

        using (var _ = new AssertionScope())
        {
            this.result.State.Should().NotBe(OperationResultState.Ok);
            this.result.State.Should().Be(OperationResultState.BadFlow);
        }
    }
}
