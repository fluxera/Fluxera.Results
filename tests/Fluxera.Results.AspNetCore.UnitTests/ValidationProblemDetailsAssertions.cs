namespace Fluxera.Results.AspNetCore.UnitTests
{
	using System.Linq;
	using FluentAssertions;
	using FluentAssertions.Execution;
	using FluentAssertions.Primitives;
	using Microsoft.AspNetCore.Mvc;

	internal class ValidationProblemDetailsAssertions : ReferenceTypeAssertions<ValidationProblemDetails, ValidationProblemDetailsAssertions>
	{
		/// <inheritdoc />
		public ValidationProblemDetailsAssertions(ValidationProblemDetails subject) 
			: base(subject, AssertionChain.GetOrCreate())
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(ProblemDetails);

		public AndWhichConstraint<ValidationProblemDetailsAssertions, ValidationProblemDetails> HaveError(string expectedMessage, string because = "", params object[] becauseArgs)
		{
			this.CurrentAssertionChain
				.BecauseOf(because, becauseArgs)
				.Given(() => this.Subject)
				.ForCondition(problemDetails =>
                {
                    string message = problemDetails.Errors.Values.First().First();
                    return message == expectedMessage;
				})
				.FailWith("Expected problem details to contain an error with message containing {0}, but it didn't");

			return new AndWhichConstraint<ValidationProblemDetailsAssertions, ValidationProblemDetails>(this, this.Subject);
		}
	}
}
