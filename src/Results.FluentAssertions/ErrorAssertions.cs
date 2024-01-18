namespace MadEyeMatt.Results.FluentAssertions
{
	using global::FluentAssertions;
    using global::FluentAssertions.Execution;
    using global::FluentAssertions.Primitives;
	using JetBrains.Annotations;

	/// <summary>
	///		Assertions for the <see cref="IError"/> type.
	/// </summary>
	[PublicAPI]
	public sealed class ErrorAssertions : ReferenceTypeAssertions<IError, ErrorAssertions>
	{
		static ErrorAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public ErrorAssertions(IError subject) 
			: base(subject)
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(IError);

		/// <summary>
		///		Asserts if the reason has a specific metadata.
		/// </summary>
		/// <param name="metadataKey"></param>
		/// <param name="metadataValue"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ErrorAssertions, IError> HaveMetadata(string metadataKey, object metadataValue, string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Metadata)
                .ForCondition(metadata =>
                {
                    metadata.TryGetValue(metadataKey, out object actualMetadataValue);
                    return actualMetadataValue == metadataValue;
                })
                .FailWith($"Expected error metadata to contain '{metadataKey}' with '{metadataValue}', but it does not");

            return new AndWhichConstraint<ErrorAssertions, IError>(this, this.Subject);
		}
	}
}