namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
	using global::FluentAssertions;
    using global::FluentAssertions.Execution;

    internal static class BeSuccessfulAssertion
    {
        public static AndWhichConstraint<TResultAssertion, TResult> Do<TResultAssertion, TResult>(TResult subject, TResultAssertion parentConstraint, string because, params object[] becauseArgs)
            where TResult : ResultBase
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => subject.IsSuccessful)
                .ForCondition(isSuccess => isSuccess)
                .FailWith("Expected result to be successful, but is was failed because of {0}", subject.Errors);

            return new AndWhichConstraint<TResultAssertion, TResult>(parentConstraint, subject);
        }
    }
}