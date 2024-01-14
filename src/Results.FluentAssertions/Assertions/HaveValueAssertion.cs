namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
	using global::FluentAssertions;
	using global::FluentAssertions.Execution;

	internal static class HaveValueAssertion
	{
		public static AndConstraint<TResultAssertion> Do<TResult, TValue, TResultAssertion>(ResultBase<TResult, TValue> subject, TResultAssertion parentConstraint, TValue expectedValue, string because, params object[] becauseArgs) 
			where TResult : ResultBase<TResult, TValue>
		{
			Execute.Assertion
				.BecauseOf(because)
				.ForCondition(subject.IsSuccessful)
				.FailWith("Value can not be asserted because the result is failed because of {0}", subject.Errors)
				.Then
				.Given(() => subject.Value)
				.ForCondition(actualValue => (actualValue == null && expectedValue == null) || actualValue.Equals(expectedValue))
				.FailWith("Expected value is {0}, but it is {1}", expectedValue, subject.Value);

			return new AndConstraint<TResultAssertion>(parentConstraint);
		}
	}
}
