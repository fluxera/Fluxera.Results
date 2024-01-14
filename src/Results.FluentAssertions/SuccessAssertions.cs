namespace MadEyeMatt.Results.FluentAssertions
{
	using global::FluentAssertions;
	using global::FluentAssertions.Primitives;
	using JetBrains.Annotations;
	using MadEyeMatt.Results.FluentAssertions.Assertions;

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
			: base(subject)
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
			return HaveMetadataAssertion.Do(this.Subject, this, metadataKey, metadataValue, because, becauseArgs);
		}
	}
}