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
    public class BeFailedTests
    {
        private readonly TestMode mode;

        public BeFailedTests(TestMode mode)
        {
            this.mode = mode;
        }

        [Test]
        public void ShouldNotThrow_ForFailedResult()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Fail("error");

                return () => result.Should().BeFailed();
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Fail<int>("error");

                return () => result.Should().BeFailed();
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("error");

            //    return () => result.Should().BeFailed();
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("error");

            //    return () => result.Should().BeFailed();
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
        public void ShouldThrow_ForSuccessfulResult()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Ok();

                return () => result.Should().BeFailed();
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Ok(42);

                return () => result.Should().BeFailed();
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>();

            //    return () => result.Should().BeFailed();
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);

            //    return () => result.Should().BeFailed();
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
                .WithMessage("Expected result to be failed, but is was successful");
        }
    }
}