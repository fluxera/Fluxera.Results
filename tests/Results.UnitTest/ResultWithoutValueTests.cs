namespace Results.UnitTest
{
	using System.Linq;
	using FluentAssertions;
	using MadEyeMatt.Results;
	using NUnit.Framework;

	[TestFixture]
	public class ResultWithoutValueTests
	{
		[Test]
		public void ShouldCreateOkResult()
		{
			Result result = Result.Ok();

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkResult_WithSuccess()
		{
			Result result = Result.Ok().WithSuccess("first success");

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
			Result result = Result.Ok().WithSuccess("first success").WithSuccess("second success");

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
			Result result = Result.Ok().WithSuccesses(new string[] { "first success", "second success" });

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
			Result result = Result.Fail("first error");

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
			Result result = Result.Fail("first error").WithError("second error");

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
			Result result = Result.Fail("first error").WithError("second error").WithError("third error");

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
			Result result = Result.Fail("first error").WithErrors(new string[] { "second error", "third error" });

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
			Result result = Result.OkIf(true, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkIfResult_Fail()
		{
			Result result = Result.OkIf(false, "first error");

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
			Result result = Result.FailIf(false, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailIfResult_Fail()
		{
			Result result = Result.FailIf(true, "first error");

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
			Result result = Result.Merge(Result.Ok().WithSuccess("first success"), Result.Ok());

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldMergeResults_Fail()
		{
			Result result = Result.Merge(Result.Ok(), Result.Fail("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Ok()
		{
			BatchResult<Result> result = Result.Batch(Result.Ok().WithSuccess("first success"), Result.Ok());

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Fail()
		{
			BatchResult<Result> result = Result.Batch(Result.Ok(), Result.Fail("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}
	}
}