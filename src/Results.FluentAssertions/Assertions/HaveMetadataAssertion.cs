namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
	using global::FluentAssertions;
	using global::FluentAssertions.Execution;

	internal static class HaveMetadataAssertion
	{
		public static AndWhichConstraint<ErrorAssertions, IError> Do(IError subject, ErrorAssertions parentConstraint, string metadataKey, object metadataValue, string because, params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.Given(() => subject.Metadata)
				.ForCondition(metadata =>
				{
					metadata.TryGetValue(metadataKey, out object actualMetadataValue);
					return actualMetadataValue == metadataValue;
				})
				.FailWith($"Expected error metadata to contain '{metadataKey}' with '{metadataValue}', but it does not");

			return new AndWhichConstraint<ErrorAssertions, IError>(parentConstraint, subject);
		}

		public static AndWhichConstraint<SuccessAssertions, ISuccess> Do(ISuccess subject, SuccessAssertions parentConstraint, string metadataKey, object metadataValue, string because, params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.Given(() => subject.Metadata)
				.ForCondition(metadata =>
				{
					metadata.TryGetValue(metadataKey, out object actualMetadataValue);
					return actualMetadataValue == metadataValue;
				})
				.FailWith($"Expected success metadata to contain '{metadataKey}' with '{metadataValue}', but it does not");

			return new AndWhichConstraint<SuccessAssertions, ISuccess>(parentConstraint, subject);
		}
	}
}