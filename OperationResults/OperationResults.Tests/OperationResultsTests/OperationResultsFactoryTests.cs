namespace OperationResults.Tests._OperationResultsTests;

public class OperationResultsFactoryTests
{
    [Fact]
    public void CreateOperationResult_Success_Test()
    {
        var result = OperationResultFactory.Create();
        result.State.Should().Be(OperationResultState.Processing);
    }
}
