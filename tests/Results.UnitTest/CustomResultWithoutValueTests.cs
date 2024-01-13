namespace Results.UnitTest
{
	using System.Linq;
	using FluentAssertions;
	using MadEyeMatt.Results;
	using NUnit.Framework;

	[TestFixture]
	public class CustomResultWithoutValueTests
	{
		[Test]
		public void ShouldCreateOkResult()
		{
			CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>();

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkResult_WithSuccess()
		{
			CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess("first success");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(1);
			result.Successes.First().Message.Should().Be("first success");
		}

		[Test]
		public void ShouldCreateOkResult_MultipleWithSuccess()
		{
			CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess("first success").WithSuccess("second success");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(2);
			result.Successes[0].Message.Should().Be("first success");
			result.Successes[1].Message.Should().Be("second success");
		}

		[Test]
		public void ShouldCreateOkResult_WithSuccesses()
		{
			CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccesses(new string[] { "first success", "second success" });

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(2);
			result.Successes[0].Message.Should().Be("first success");
			result.Successes[1].Message.Should().Be("second success");
		}

		[Test]
		public void ShouldCreateFailResult()
		{
			CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailResult_WithError()
		{
			CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("first error").WithError("second error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(2);
			result.Errors[0].Message.Should().Be("first error");
			result.Errors[1].Message.Should().Be("second error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailResult_MultipleWithError()
		{
			CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("first error").WithError("second error").WithError("third error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(3);
			result.Errors[0].Message.Should().Be("first error");
			result.Errors[1].Message.Should().Be("second error");
			result.Errors[2].Message.Should().Be("third error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailResult_WithErrors()
		{
			CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("first error").WithErrors(new string[] { "second error", "third error" });

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(3);
			result.Errors[0].Message.Should().Be("first error");
			result.Errors[1].Message.Should().Be("second error");
			result.Errors[2].Message.Should().Be("third error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkIfResult_Ok()
		{
			CustomResultWithoutValue result = Result.OkIf<CustomResultWithoutValue>(true, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkIfResult_Fail()
		{
			CustomResultWithoutValue result = Result.OkIf<CustomResultWithoutValue>(false, "first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailIfResult_Ok()
		{
			CustomResultWithoutValue result = Result.FailIf<CustomResultWithoutValue>(false, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailIfResult_Fail()
		{
			CustomResultWithoutValue result = Result.FailIf<CustomResultWithoutValue>(true, "first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldMergeResults_Ok()
		{
			CustomResultWithoutValue result = Result.Merge(Result.Ok<CustomResultWithoutValue>().WithSuccess("first success"), Result.Ok<CustomResultWithoutValue>());

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldMergeResults_Fail()
		{
			CustomResultWithoutValue result = Result.Merge(Result.Ok<CustomResultWithoutValue>(), Result.Fail<CustomResultWithoutValue>("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Ok()
		{
			BatchResult<CustomResultWithoutValue> result = Result.Batch(Result.Ok<CustomResultWithoutValue>().WithSuccess("first success"), Result.Ok<CustomResultWithoutValue>());

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Fail()
		{
			BatchResult<CustomResultWithoutValue> result = Result.Batch(Result.Ok<CustomResultWithoutValue>(), Result.Fail<CustomResultWithoutValue>("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}
	}
}