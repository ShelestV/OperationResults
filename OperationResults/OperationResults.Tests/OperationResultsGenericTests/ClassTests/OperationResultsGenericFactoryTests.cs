namespace OperationResults.Tests._OperationResultsGenericTests.ClassTests;

public class OperationResultsGenericFactoryTests
{
    [Fact]
    public void CreateOperationResultClass_Success_Test()
    {
        var result = OperationResultFactory.Create<string>();
        using (var _ = new AssertionScope())
            result.State.Should().Be(OperationResultState.Processing);

        result.Done(string.Empty);

        using (var _ = new AssertionScope())
            result.Result.Should().BeOfType<string>();
    }
}
