namespace Fluxera.Results.FluentAssertions
{
	using global::FluentAssertions;
	using global::FluentAssertions.Execution;
	using global::FluentAssertions.Primitives;
	using JetBrains.Annotations;

	/// <summary>
	///		Assertions for the <see cref="ISuccess"/> type.
	/// </summary>
	[PublicAPI]
	public sealed class SuccessAssertions : ReferenceTypeAssertions<ISuccess, SuccessAssertions>
	{
		static SuccessAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public SuccessAssertions(ISuccess subject)
			: base(subject, AssertionChain.GetOrCreate())
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(ISuccess);

		/// <summary>
		///		Asserts if the reason has a specific metadata.
		/// </summary>
		/// <param name="metadataKey"></param>
		/// <param name="metadataValue"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<SuccessAssertions, ISuccess> HaveMetadata(string metadataKey, object metadataValue, string because = "", params object[] becauseArgs)
		{
			this.CurrentAssertionChain
				.BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Metadata)
                .ForCondition(metadata =>
                {
                    metadata.TryGetValue(metadataKey, out object actualMetadataValue);
                    return actualMetadataValue == metadataValue;
                })
                .FailWith($"Expected success metadata to contain '{metadataKey}' with '{metadataValue}', but it does not");

            return new AndWhichConstraint<SuccessAssertions, ISuccess>(this, this.Subject);
		}
	}
}