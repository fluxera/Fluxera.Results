namespace Results.FluentAssertions.UnitTests.Assertions
{
	using MadEyeMatt.Results;
	using NUnit.Framework;
	using System;
	using global::FluentAssertions;
	using MadEyeMatt.Results.FluentAssertions;

    [TestFixture(TestMode.ResultWithValue)]
	//[TestFixture(TestMode.CustomResultWithValue)]
	public class HaveValueTests
	{
		private readonly TestMode mode;

		public HaveValueTests(TestMode mode)
		{
			this.mode = mode;
		}

		[Test]
		public void ShouldNotThrow_WithExpectedValue()
		{
			Action AssertResultWithValue()
			{
				Result<int> result = Result.Ok(42);

				return () => result.Should().HaveValue(42);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);

			//	return () => result.Should().HaveValue(42);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}

		[Test]
		public void ShouldThrow_WithWrongExpectedValue()
		{
			Action AssertResultWithValue()
			{
				Result<int> result = Result.Ok(42);

				return () => result.Should().HaveValue(41);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);

			//	return () => result.Should().HaveValue(41);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should()
				.Throw<AssertionException>()
				.WithMessage("Expected value is 41, but it is 42");
		}

		[Test]
		public void ShouldThrow_WithFailedResult()
		{
			Action AssertResultWithValue()
			{
				Result<int> result = Result.Fail<int>("error");

				return () => result.Should().HaveValue(42);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("error");

			//	return () => result.Should().HaveValue(42);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should()
				.Throw<AssertionException>()
				.WithMessage("Value can not be asserted because the result is failed because of \"error\"");
		}

		[Test]
		public void ShouldNotThrow_WithPrimitiveNullValue()
		{
			Action AssertResultWithValue()
			{
				Result<int?> result = Result.Ok((int?)null);

				return () => result.Should().HaveValue(null);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValuePrimitiveNullable result = Result<int?>.Ok<CustomResultWithValuePrimitiveNullable>(null);

			//	return () => result.Should().HaveValue(null);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}

		[Test]
		public void ShouldNotThrow_WithStructNullValue()
		{
			Action AssertResultWithValue()
			{
				Result<TestStruct?> result = Result.Ok((TestStruct?)null);

				return () => result.Should().HaveValue(null);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValueStructNullable result = Result<TestStruct?>.Ok<CustomResultWithValueStructNullable>(null);

			//	return () => result.Should().HaveValue(null);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}

		[Test]
		public void ShouldNotThrow_WithClassNullValue()
		{
			Action AssertResultWithValue()
			{
				Result<TestClass> result = Result.Ok((TestClass)null);

				return () => result.Should().HaveValue(null);
			}

			//Action AssertCustomResultWithValue()
			//{
			//	CustomResultWithValueClassNullable result = Result<TestClass>.Ok<CustomResultWithValueClassNullable>(null);

			//	return () => result.Should().HaveValue(null);
			//}

			Action action = this.mode switch
			{
				TestMode.ResultWithValue => AssertResultWithValue(),
				//TestMode.CustomResultWithValue => AssertCustomResultWithValue(),
				_ => throw new ArgumentOutOfRangeException()
			};

			action.Should().NotThrow();
		}
	}
}