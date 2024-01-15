namespace Results.AspNetCode.UnitTests
{
	using System;
	using Microsoft.AspNetCore.Mvc;

	internal static class ValidationProblemDetailsExtensions
	{
		public static ValidationProblemDetailsAssertions Should(this ValidationProblemDetails problemDetails)
		{
			if (problemDetails == null) throw new ArgumentNullException(nameof(problemDetails));

			return new ValidationProblemDetailsAssertions(problemDetails);
		}
	}
}