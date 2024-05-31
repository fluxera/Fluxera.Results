namespace Fluxera.Results.FluentAssertions.UnitTests.Assertions
{
	using System;
	using FluentAssertions;
	using Fluxera.Results;
	using global::FluentAssertions;
	using NUnit.Framework;

	[TestFixture(TestMode.ResultWithoutValue)]
	[TestFixture(TestMode.ResultWithValue)]
	//[TestFixture(TestMode.CustomResultWithoutValue)]
	//[TestFixture(TestMode.CustomResultWithValue)]
	public class HaveSuccessTests
	{
		private readonly TestMode mode;

		public HaveSuccessTests(TestMode mode)
		{
			this.mode = mode;
		}

		[Test]
		public void ShouldNotThrow_WithExpectedSuccess()
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Ok().WithSuccess("success");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess("success");
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Ok(42).WithSuccess("success");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess("success");
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess("success");

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess("success");
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess("success"); ;

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess("success");
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
		[TestCase("success")]
		[TestCase("success message")]
		[TestCase("this is a success message")]
		public void ShouldNotThrow_WithContainsPartExpectedSuccess(string expectedMessage)
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Ok().WithSuccess("this is a success message");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess(expectedMessage, MessageComparison.Contains);
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Ok(42).WithSuccess("this is a success message");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess(expectedMessage, MessageComparison.Contains);
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess("this is a success message");

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess(expectedMessage, MessageComparison.Contains);
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess("this is a success message");

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess(expectedMessage, MessageComparison.Contains);
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
		public void ShouldThrow_WithNotExpectedSuccess()
		{
			Action AssertResultWithoutValue()
			{
				Result result = Result.Ok().WithSuccess("success-message");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess("success");
			}

			Action AssertResultWithValue()
			{
				Result<int> result = Result.Ok(42).WithSuccess("success-message");

				return () => result.Should().BeSuccessful()
					.And.HaveSuccess("success");
			}

			//Action AssertCustomResultWithoutValue()
			//{
			//	CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess("success-message");

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess("success");
			//}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess("success-message");

			//	return () => result.Should().BeSuccessful()
			//		.And.HaveSuccess("success");
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
				.WithMessage("Expected result to contain a success with message containing \"success\", but found successes \"success-message\"");
		}
	}
}