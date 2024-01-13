namespace Results.UnitTest
{
	using FluentAssertions;
	using MadEyeMatt.Results;
	using NUnit.Framework;

	[TestFixture]
	public class SuccessTests
	{
		[Test]
		public void ShouldCreateSuccessWithNullMessage()
		{
			Success error = new Success(null);

			error.Message.Should().BeNull();
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateSuccessWithEmptyMessage()
		{
			Success error = new Success(string.Empty);

			error.Message.Should().BeEmpty();
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateSuccessWithMessage()
		{
			Success error = new Success("success");

			error.Message.Should().Be("success");
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldUpdateMessageUsingWithMessage()
		{
			Success error = new Success();
			error.WithMessage("other success");

			error.Message.Should().Be("other success");
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldAddMetadata()
		{
			Success error = new Success("success");
			error.WithMetadata("test", "value");

			error.Message.Should().Be("success");
			error.Metadata.Keys.Should().NotBeEmpty();
			error.Metadata.Should().HaveCount(1);
			error.Metadata.Should().ContainKey("test");
			error.Metadata.Should().ContainValue("value");
		}
	}
}