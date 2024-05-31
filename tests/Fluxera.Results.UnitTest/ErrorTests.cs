namespace Fluxera.Results.UnitTest
{
	using FluentAssertions;
	using Fluxera.Results;
	using NUnit.Framework;

	[TestFixture]
	public class ErrorTests
	{
		[Test]
		public void ShouldCreateErrorWithNullMessage()
		{
			Error error = new Error(null);

			error.Message.Should().BeNull();
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateErrorWithEmptyMessage()
		{
			Error error = new Error(string.Empty);

			error.Message.Should().BeEmpty();
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldCreateErrorWithMessage()
		{
			Error error = new Error("error");

			error.Message.Should().Be("error");
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldUpdateMessageUsingWithMessage()
		{
			Error error = new Error();
			error.WithMessage("other error");

			error.Message.Should().Be("other error");
			error.Metadata.Keys.Should().BeEmpty();
		}

		[Test]
		public void ShouldAddMetadata()
		{
			Error error = new Error("error");
			error.WithMetadata("test", "value");

			error.Message.Should().Be("error");
			error.Metadata.Keys.Should().NotBeEmpty();
			error.Metadata.Should().HaveCount(1);
			error.Metadata.Should().ContainKey("test");
			error.Metadata.Should().ContainValue("value");
		}
	}
}
