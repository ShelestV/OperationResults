namespace OperationResults.Tests;

public class OperationResultsGenericTests
{
	public class OperationResultGenericFactoryTests : OperationResultsGenericTests
	{
		public class OperationResultGenericFactoryStructTests : OperationResultGenericFactoryTests
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

		public class OperationResultGenericFactoryClassTests : OperationResultGenericFactoryTests
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
	}

	public class OperationResultsGenericSuccessTests : OperationResultsGenericTests
	{
		public class OperationResulsGenericStructSuccessTests : OperationResultsGenericSuccessTests
		{
			private IOperationResult<Guid> result = OperationResultFactory.Create<Guid>();

			private void ReserResult()
			{
				result = OperationResultFactory.Create<Guid>();
			}

			[Fact]
			public void DefaultBehaviour_Success_Test()
			{
				this.ReserResult();

				using var _ = new AssertionScope();
				this.result.State.Should().Be(OperationResultState.Processing);
				this.result.Invoking(x => x.Result).Should().Throw<OperationStillProcessingException>();
				this.result.Invoking(x => x.Exception).Should().Throw<OperationStillProcessingException>();
			}

			[Fact]
			public void DoneOperationResult_Success_Test()
			{
				this.ReserResult();

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
				this.ReserResult();

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
				this.ReserResult();

				this.result.NotFound();

				using var _ = new AssertionScope();
				this.result.State.Should().Be(OperationResultState.NotFound);
				this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
				this.result.Invoking(x => x.Result).Should().Throw<IncorrectOperationResultStateException>();
			}
		}

		public class OperationResulsGenericClassSuccessTests : OperationResultsGenericSuccessTests
		{
			private IOperationResult<string> result = OperationResultFactory.Create<string>();

			private void ReserResult()
			{
				result = OperationResultFactory.Create<string>();
			}

			[Fact]
			public void DefaultBehaviour_Success_Test()
			{
				this.ReserResult();

				using var _ = new AssertionScope();
				this.result.State.Should().Be(OperationResultState.Processing);
				this.result.Invoking(x => x.Result).Should().Throw<OperationStillProcessingException>();
				this.result.Invoking(x => x.Exception).Should().Throw<OperationStillProcessingException>();
			}

			[Fact]
			public void DoneOperationResult_Success_Test()
			{
				this.ReserResult();

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
				this.ReserResult();

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
				this.ReserResult();

				this.result.NotFound();

				using var _ = new AssertionScope();
				this.result.State.Should().Be(OperationResultState.NotFound);
				this.result.Invoking(x => x.Exception).Should().Throw<IncorrectOperationResultStateException>();
				this.result.Invoking(x => x.Result).Should().Throw<IncorrectOperationResultStateException>();
			}
		}
	}
}