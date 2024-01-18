#if NET7_0_OR_GREATER
namespace MadEyeMatt.Results.AspNetCode.Transformers
{
    using JetBrains.Annotations;
    using MadEyeMatt.Results;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.DependencyInjection;
    using IResult = MadEyeMatt.Results.IResult;
    using IHttpResult = Microsoft.AspNetCore.Http.IResult;

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
        protected override IHttpResult TransformFailedResult(IResult result)
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
        protected override IHttpResult TransformFailedResult<TValue>(IResult<TValue> result)
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