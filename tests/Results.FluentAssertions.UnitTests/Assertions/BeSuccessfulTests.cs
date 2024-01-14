namespace Results.FluentAssertions.UnitTests.Assertions
{
    using System;
    using global::FluentAssertions;
    using MadEyeMatt.Results;
    using MadEyeMatt.Results.FluentAssertions;
    using NUnit.Framework;

    [TestFixture(TestMode.ResultWithoutValue)]
    [TestFixture(TestMode.ResultWithValue)]
    [TestFixture(TestMode.CustomResultWithoutValue)]
    [TestFixture(TestMode.CustomResultWithValue)]
    public class BeSuccessfulTests
    {
        private readonly TestMode mode;

        public BeSuccessfulTests(TestMode mode)
        {
            this.mode = mode;
        }

        [Test]
        public void ShouldNotThrow_ForSuccessfulResult()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Ok();

                return () => result.Should().BeSuccessful();
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result<int>.Ok(42);

                return () => result.Should().BeSuccessful();
            }

            Action AssertCustomResultWithoutValue()
            {
                CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>();

                return () => result.Should().BeSuccessful();
            }

            Action AssertCustomResultWithValue()
            {
                CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);

                return () => result.Should().BeSuccessful();
            }

            Action action = this.mode switch
            {
                TestMode.ResultWithoutValue => AssertResultWithoutValue(),
                TestMode.ResultWithValue => AssertResultWithValue(),
                TestMode.CustomResultWithoutValue => AssertCustomResultWithoutValue(),
                TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
                _ => throw new ArgumentOutOfRangeException()
            };

            action.Should().NotThrow();
        }

        [Test]
        public void ShouldThrow_ForFailedResult()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Fail("error");

                return () => result.Should().BeSuccessful();
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result<int>.Fail("error");

                return () => result.Should().BeSuccessful();
            }

            Action AssertCustomResultWithoutValue()
            {
                CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("error");

                return () => result.Should().BeSuccessful();
            }

            Action AssertCustomResultWithValue()
            {
                CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("error");

                return () => result.Should().BeSuccessful();
            }

            Action action = this.mode switch
            {
                TestMode.ResultWithoutValue => AssertResultWithoutValue(),
                TestMode.ResultWithValue => AssertResultWithValue(),
                TestMode.CustomResultWithoutValue => AssertCustomResultWithoutValue(),
                TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
                _ => throw new ArgumentOutOfRangeException()
            };

            action.Should()
                .Throw<AssertionException>()
                .WithMessage("Expected result to be successful, but is was failed because of \"error\"");
        }
    }
}