namespace Results.FluentAssertions.UnitTests.Assertions
{
	using NUnit.Framework;
	using System;
	using Fluxera.Results;
	using Fluxera.Results.FluentAssertions;
	using global::FluentAssertions;

	[TestFixture(TestMode.ResultWithoutValue)]
	[TestFixture(TestMode.ResultWithValue)]
	//[TestFixture(TestMode.CustomResultWithoutValue)]
	//[TestFixture(TestMode.CustomResultWithValue)]
	public class HaveErrorTests
	{
		private readonly TestMode mode;

		public HaveErrorTests(TestMode mode)
		{
			this.mode = mode;
		}

		[Test]
		public void ShouldNotThrow_WithExpectedError()
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Fail("error");

				return () => result.Should().BeFailed()
					.And.HaveError("error");
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Fail<int>("error");

				return () => result.Should().BeFailed()
					.And.HaveError("error");
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("error");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError("error");
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("error");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError("error");
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithoutValue => AssertResultWithoutValue(),
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithoutValue => AssertCustomResultWithoutValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}

		[Test]
		[TestCase("error")]
		[TestCase("error message")]
		[TestCase("this is an error message")]
		public void ShouldNotThrow_WithContainsPartExpectedError(string expectedMessage)
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Fail("this is an error message");

				return () => result.Should().BeFailed()
					.And.HaveError(expectedMessage, MessageComparison.Contains);
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Fail<int>("this is an error message");

				return () => result.Should().BeFailed()
					.And.HaveError(expectedMessage, MessageComparison.Contains);
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("this is an error message");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError(expectedMessage, MessageComparison.Contains);
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("this is an error message");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError(expectedMessage, MessageComparison.Contains);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithoutValue => AssertResultWithoutValue(),
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithoutValue => AssertCustomResultWithoutValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}

		[Test]
		public void ShouldThrow_WithNotExpectedError()
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Fail("error-message");

				return () => result.Should().BeFailed()
					.And.HaveError("error");
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Fail<int>("error-message");

				return () => result.Should().BeFailed()
					.And.HaveError("error");
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("error-message");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError("error");
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("error-message");

			//	return () => result.Should().BeFailed()
			//		.And.HaveError("error");
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithoutValue => AssertResultWithoutValue(),
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithoutValue => AssertCustomResultWithoutValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should()
				.Throw<AssertionException>()
				.WithMessage("Expected result to contain an error with message containing \"error\", but found errors \"error-message\"");
		}
	}
}