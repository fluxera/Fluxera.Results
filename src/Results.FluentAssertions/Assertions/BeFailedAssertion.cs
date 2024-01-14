namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
    using global::FluentAssertions;
    using global::FluentAssertions.Execution;

    internal static class BeFailedAssertion
    {
        public static AndWhichConstraint<TResultAssertion, TResult> Do<TResultAssertion, TResult>(TResult subject, TResultAssertion parentConstraint, string because, params object[] becauseArgs)
            where TResult : ResultBase
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => subject.IsFailed)
                .ForCondition(isFailed => isFailed)
                .FailWith("Expected result to be failed, but is was successful");

            return new AndWhichConstraint<TResultAssertion, TResult>(parentConstraint, subject);
        }
    }
}