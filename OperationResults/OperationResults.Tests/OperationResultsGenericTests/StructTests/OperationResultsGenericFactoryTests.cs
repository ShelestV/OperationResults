namespace OperationResults.Tests._OperationResultsGenericTests.StructTests;

public class OperationResultsGenericFactoryTests
{
    [Fact]
    public void CreateOperationResultStruct_Success_Test()
    {
        var result = OperationResultFactory.Create<Guid>();
        using (var _ = new AssertionScope())
            result.State.Should().Be(OperationResultState.Processing);

        result.Done(Guid.Empty);

        using (var _ = new AssertionScope())
            result.Result.GetType().Should().Be(typeof(Guid));
    }
}
