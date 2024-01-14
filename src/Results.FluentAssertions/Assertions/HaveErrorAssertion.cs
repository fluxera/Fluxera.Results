namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
    using System;
    using System.Linq;
    using global::FluentAssertions.Execution;
    using MadEyeMatt.Results.FluentAssertions;

    internal static class HaveErrorAssertion
	{
		public static AndWhichThatConstraint<TResultAssertion, TResult, ErrorAssertions> Do<TResultAssertion, TResult>(TResult subject, TResultAssertion parentConstraint, string expectedMessage, Func<string, string, bool> messageComparison, string because, params object[] becauseArgs)
			where TResult : ResultBase
		{
			messageComparison ??= MessageComparison.Equal;

			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.Given(() => subject.Errors)
				.ForCondition(errors => errors.Any(error => messageComparison(error.Message, expectedMessage)))
				.FailWith("Expected result to contain an error with message containing {0}, but found errors {1}", expectedMessage, subject.Errors);

			return new AndWhichThatConstraint<TResultAssertion, TResult, ErrorAssertions>(parentConstraint, subject, new ErrorAssertions(subject.Errors.SingleOrDefault(reason => messageComparison(reason.Message, expectedMessage))));
		}
	}
}