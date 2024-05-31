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
    public class HaveMetadataTests
    {
        private readonly TestMode mode;

        public HaveMetadataTests(TestMode mode)
        {
            this.mode = mode;
        }

        [Test]
        public void ShouldNotThrow_ForErrorWithSpecificMetadata()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Fail(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata("key", "value");
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Fail<int>(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata("key", "value");
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata("key", "value");
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata("key", "value");
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
        [TestCase(null)]
        [TestCase("wrongValue")]
        [TestCase(42)]
        public void ShouldThrow_ForErrorWithWrongMetadataValue(object expectedMetadataValue)
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Fail(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata("key", expectedMetadataValue);
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Fail<int>(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata("key", expectedMetadataValue);
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata("key", expectedMetadataValue);
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata("key", expectedMetadataValue);
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
                .WithMessage($"Expected error metadata to contain 'key' with '{expectedMetadataValue}', but it does not");
        }

        [Test]
        [TestCase("wrongKey")]
        [TestCase("ke")]
        public void ShouldThrow_ForErrorWithWrongMetadataKey(string expectedMetadataKey)
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Fail(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata(expectedMetadataKey, "value");
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Fail<int>(new Error("error").WithMetadata("key", "value"));

                return () => result.Should().BeFailed()
                    .And.HaveError("error")
                    .That.HaveMetadata(expectedMetadataKey, "value");
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata(expectedMetadataKey, "value");
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>(new Error("error").WithMetadata("key", "value"));

            //    return () => result.Should().BeFailed()
            //        .And.HaveError("error")
            //        .That.HaveMetadata(expectedMetadataKey, "value");
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
                .WithMessage($"Expected error metadata to contain '{expectedMetadataKey}' with 'value', but it does not");
        }

        [Test]
        public void ShouldNotThrow_ForSuccessWithSpecificMetadata()
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Ok().WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata("key", "value");
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Ok(42).WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata("key", "value");
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess(new Success("success").WithMetadata("key", "value"));

            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata("key", "value");
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess(new Success("success").WithMetadata("key", "value"));
            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata("key", "value");
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
        [TestCase(null)]
        [TestCase("wrongValue")]
        [TestCase(42)]
        public void ShouldThrow_ForSuccessWithWrongMetadataValue(object expectedMetadataValue)
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Ok().WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata("key", expectedMetadataValue);
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Ok(42).WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata("key", expectedMetadataValue);
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess(new Success("success").WithMetadata("key", "value"));

            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata("key", expectedMetadataValue);
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess(new Success("success").WithMetadata("key", "value"));
            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata("key", expectedMetadataValue);
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
                .WithMessage($"Expected success metadata to contain 'key' with '{expectedMetadataValue}', but it does not");
        }

        [Test]
        [TestCase("wrongKey")]
        [TestCase("ke")]
        public void ShouldThrow_ForSuccessWithWrongMetadataKey(string expectedMetadataKey)
        {
            Action AssertResultWithoutValue()
            {
                Result result = Result.Ok().WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata(expectedMetadataKey, "value");
            }

            Action AssertResultWithValue()
            {
                Result<int> result = Result.Ok(42).WithSuccess(new Success("success").WithMetadata("key", "value"));

                return () => result.Should().BeSuccessful()
                    .And.HaveSuccess("success")
                    .That.HaveMetadata(expectedMetadataKey, "value");
            }

            //Action AssertCustomResultWithoutValue()
            //{
            //    CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>().WithSuccess(new Success("success").WithMetadata("key", "value"));

            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata(expectedMetadataKey, "value");
            //}

            //Action AssertCustomResultWithValue()
            //{
            //    CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42).WithSuccess(new Success("success").WithMetadata("key", "value"));
            //    return () => result.Should().BeSuccessful()
            //        .And.HaveSuccess("success")
            //        .That.HaveMetadata(expectedMetadataKey, "value");
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
                .WithMessage($"Expected success metadata to contain '{expectedMetadataKey}' with 'value', but it does not");
        }
    }
}