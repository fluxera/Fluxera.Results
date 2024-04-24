#if NET7_0_OR_GREATER
namespace MadEyeMatt.Results.AspNetCore.Transformers
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

	/// <summary>
	///		The default implementation with sane, opinionated transformation rules.
	/// </summary>
	[PublicAPI]
    public class DefaultHttpResultTransformer : IHttpResultTransformer
    {
        /// <inheritdoc />
        public IResult Transform(Result result)
        {
            return result.IsFailed
                ? this.TransformFailedResult(result)
                : this.TransformSuccessfulResult(result);
        }

        /// <inheritdoc />
        public IResult Transform<TValue>(Result<TValue> result)
        {
            return result.IsFailed
                ? this.TransformFailedResult(result)
                : this.TransformSuccessfulResult(result);
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="Ok"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IResult TransformSuccessfulResult(Result result)
        {
            return Results.Ok();
        }

		///  <summary>
		/// 		Transforms the given result to a <see cref="Ok{TValue}"/>.
		///  </summary>
		///  <typeparam name="TValue"></typeparam>
		///  <param name="result"></param>
		///  <returns></returns>
		protected virtual IResult TransformSuccessfulResult<TValue>(Result<TValue> result)
        {
            return Results.Ok(result.GetValueOrDefault());
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="BadRequest"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IResult TransformFailedResult(Result result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            return Results.BadRequest(modelState);
        }

        ///  <summary>
        /// 		Transforms the given result to a <see cref="BadRequest"/>.
        ///  </summary>
        ///  <typeparam name="TValue"></typeparam>
        ///  <param name="result"></param>
        ///  <returns></returns>
        protected virtual IResult TransformFailedResult<TValue>(Result<TValue> result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            return Results.BadRequest(modelState);
        }
    }
}
#endif