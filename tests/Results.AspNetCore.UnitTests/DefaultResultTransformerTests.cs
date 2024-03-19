namespace Results.AspNetCore.UnitTests
{
    using System.Linq;
    using FluentAssertions;
    using MadEyeMatt.Results;
    using MadEyeMatt.Results.AspNetCore;
    using MadEyeMatt.Results.AspNetCore.Transformers;
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;

    [TestFixture]
	public class DefaultResultTransformerTests
	{
		[Test]
		public void ShouldTransformOkResultWithoutValue()
		{
			Result result = Result.Ok();

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<OkResult>();
		}

		[Test]
		public void ShouldTransformOkResultWitValue()
		{
			Result<int> result = Result<int>.Ok(42);

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(42);
		}

		[Test]
		public void ShouldTransformCustomOkResultWithoutValue()
		{
			CustomResultWithoutValue result = Result.Ok<CustomResultWithoutValue>();

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<OkResult>();
		}

		[Test]
		public void ShouldTransformCustomOkResultWithValue()
		{
			CustomResultWithValue result = Result<int>.Ok<CustomResultWithValue>(42);

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<OkObjectResult>();
		}

		[Test]
		public void ShouldTransformFailedResultWithoutValue()
		{
			Result result = Result.Fail("An error occurred.");

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);

			BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)actionResult;
			badRequestObjectResult.Value.Should().BeOfType<SerializableError>();

			SerializableError serializableError = (SerializableError)badRequestObjectResult.Value;
			serializableError.Should().NotBeNull();
			serializableError.Should().HaveCount(1);
			string[] value = (string[])serializableError.Values.First();
			value[0].Should().Be("An error occurred.");
		}

		[Test]
		public void ShouldTransformFailedResultWitValue()
		{
			Result<int> result = Result<int>.Fail("An error occurred.");

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			actionResult.Should().NotBeNull();
			actionResult.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);

			BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)actionResult;
			badRequestObjectResult.Value.Should().BeOfType<SerializableError>();

			SerializableError serializableError = (SerializableError)badRequestObjectResult.Value;
			serializableError.Should().NotBeNull();
			serializableError.Should().HaveCount(1);
			string[] value = (string[])serializableError.Values.First();
			value[0].Should().Be("An error occurred.");
		}

		[Test]
		public void ShouldTransformCustomFailedResultWithoutValue()
		{
			CustomResultWithoutValue result = Result.Fail<CustomResultWithoutValue>("An error occurred.");

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)actionResult;
			badRequestObjectResult.Value.Should().BeOfType<SerializableError>();

			SerializableError serializableError = (SerializableError)badRequestObjectResult.Value;
			serializableError.Should().NotBeNull();
			serializableError.Should().HaveCount(1);
			string[] value = (string[])serializableError.Values.First();
			value[0].Should().Be("An error occurred.");
		}

		[Test]
		public void ShouldTransformCustomFailedResultWithValue()
		{
			CustomResultWithValue result = Result<int>.Fail<CustomResultWithValue>("An error occurred.");

			IActionResultTransformer transformer = new DefaultActionResultTransformer();
			IActionResult actionResult = transformer.Transform(result);

			BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult)actionResult;
			badRequestObjectResult.Value.Should().BeOfType<SerializableError>();

			SerializableError serializableError = (SerializableError)badRequestObjectResult.Value;
			serializableError.Should().NotBeNull();
			serializableError.Should().HaveCount(1);
			string[] value = (string[])serializableError.Values.First();
			value[0].Should().Be("An error occurred.");
		}
	}
}