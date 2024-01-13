namespace Results.UnitTest
{
	using System.Collections.Generic;
	using System.Linq;
	using FluentAssertions;
	using MadEyeMatt.Results;
	using NUnit.Framework;

	[TestFixture]
	public class ResultWithValueTests
	{
		[Test]
		public void ShouldCreateOkResult()
		{
			Result<int> result = Result<int>.Ok(42);

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.Value.Should().Be(42);

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkResult_WithSuccess()
		{
			Result<int> result = Result<int>.Ok(42).WithSuccess("first success");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.Value.Should().Be(42);

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(1);
			result.Successes.First().Message.Should().Be("first success");
		}

		[Test]
		public void ShouldCreateOkResult_MultipleWithSuccess()
		{
			Result<int> result = Result<int>.Ok(42).WithSuccess("first success").WithSuccess("second success");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.Value.Should().Be(42);

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(2);
			result.Successes[0].Message.Should().Be("first success");
			result.Successes[1].Message.Should().Be("second success");
		}

		[Test]
		public void ShouldCreateOkResult_WithSuccesses()
		{
			Result<int> result = Result<int>.Ok(42).WithSuccesses(new string[] { "first success", "second success" });

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.Value.Should().Be(42);

			result.Errors.Should().BeEmpty();

			result.Successes.Should().NotBeEmpty();
			result.Successes.Should().HaveCount(2);
			result.Successes[0].Message.Should().Be("first success");
			result.Successes[1].Message.Should().Be("second success");
		}

		[Test]
		public void ShouldCreateFailResult()
		{
			Result<int> result = Result<int>.Fail("first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailResult_WithError()
		{
			Result<int> result = Result<int>.Fail("first error").WithError("second error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(2);
			result.Errors[0].Message.Should().Be("first error");
			result.Errors[1].Message.Should().Be("second error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailResult_MultipleWithError()
		{
			Result<int> result = Result<int>.Fail("first error").WithError("second error").WithError("third error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

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
			Result<int> result = Result<int>.Fail("first error").WithErrors(new string[] { "second error", "third error" });

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

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
			Result<int> result = Result<int>.OkIf(true, 42, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.Value.Should().Be(42);

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateOkIfResult_Fail()
		{
			Result<int> result = Result<int>.OkIf(false, 42, "first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailIfResult_Ok()
		{
			Result<int> result = Result<int>.FailIf(false, 42, "first error");

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();
			result.GetValueOrDefault().Should().Be(42);

			result.Errors.Should().BeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateFailIfResult_Fail()
		{
			Result<int> result = Result<int>.FailIf(true, 42, "first error");

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();
			result.GetValueOrDefault().Should().Be(default);

			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().HaveCount(1);
			result.Errors.First().Message.Should().Be("first error");

			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldMergeResults_Ok()
		{
			Result<IEnumerable<int>> result = Result<int>.Merge(Result<int>.Ok(42).WithSuccess("first success"), Result<int>.Ok(43));

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldMergeResults_Fail()
		{
			Result<IEnumerable<int>> result = Result<int>.Merge(Result<int>.Ok(42), Result<int>.Fail("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Ok()
		{
			BatchResult<Result<int>> result = Result<int>.Batch(Result<int>.Ok(42).WithSuccess("first success"), Result<int>.Ok(43));

			result.IsFailed.Should().BeFalse();
			result.IsSuccessful.Should().BeTrue();

			result.Errors.Should().BeEmpty();
			result.Successes.Should().NotBeEmpty();
		}

		[Test]
		public void ShouldBatchResults_Fail()
		{
			BatchResult<Result<int>> result = Result<int>.Batch(Result<int>.Ok(42), Result<int>.Fail("first error"));

			result.IsFailed.Should().BeTrue();
			result.IsSuccessful.Should().BeFalse();

			result.Errors.Should().NotBeEmpty();
			result.Successes.Should().BeEmpty();
		}
	}
}