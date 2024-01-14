namespace MadEyeMatt.Results.FluentAssertions.Assertions
{
	using System;
	using System.Linq;
	using global::FluentAssertions.Execution;

	internal static class HaveSuccessAssertion
	{
		public static AndWhichThatConstraint<TResultAssertion, TResult, SuccessAssertions> Do<TResultAssertion, TResult>(TResult subject, TResultAssertion parentConstraint, string expectedMessage, Func<string, string, bool> messageComparison, string because, params object[] becauseArgs)
			where TResult : ResultBase
		{
			messageComparison ??= MessageComparison.Equal;

			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.Given(() => subject.Successes)
				.ForCondition(successes => successes.Any(error => messageComparison(error.Message, expectedMessage)))
				.FailWith("Expected result to contain a success with message containing {0}, but found successes {1}", expectedMessage, subject.Successes);

			return new AndWhichThatConstraint<TResultAssertion, TResult, SuccessAssertions>(parentConstraint, subject, new SuccessAssertions(subject.Successes.SingleOrDefault(reason => messageComparison(reason.Message, expectedMessage))));
		}
	}
}