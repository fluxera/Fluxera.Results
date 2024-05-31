#if NET7_0_OR_GREATER
namespace Fluxera.Results.AspNetCore.Transformers
{
	using Fluxera.Results;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Http.HttpResults;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	///		The default implementation with sane, opinionated transformation rules.
	/// </summary>
	[PublicAPI]
    public class ProblemDetailsHttpResultTransformer : DefaultHttpResultTransformer
    {
        private readonly HttpContext httpContext;

		///  <summary>
		/// 		Initializes a new instance of the <see cref="ProblemDetailsHttpResultTransformer"/>
		///  </summary>
		///  <param name="httpContext"></param>
		public ProblemDetailsHttpResultTransformer(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="BadRequest"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override IResult TransformFailedResult(Result result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            ProblemDetailsFactory problemDetailsFactory = this.httpContext.RequestServices.GetService<ProblemDetailsFactory>();
            ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(this.httpContext,
                modelState, title: "One or more errors occurred.", statusCode: 400);

            return Results.BadRequest(problemDetails);
        }

        ///  <summary>
        /// 		Transforms the given result to a <see cref="BadRequest"/>.
        ///  </summary>
        ///  <typeparam name="TValue"></typeparam>
        ///  <param name="result"></param>
        ///  <returns></returns>
        protected override IResult TransformFailedResult<TValue>(Result<TValue> result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            ProblemDetailsFactory problemDetailsFactory = this.httpContext.RequestServices.GetService<ProblemDetailsFactory>();
            ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(this.httpContext,
                modelState, title: "One or more errors occurred.", statusCode: 400);

            return Results.BadRequest(problemDetails);
		}
    }
}
#endif