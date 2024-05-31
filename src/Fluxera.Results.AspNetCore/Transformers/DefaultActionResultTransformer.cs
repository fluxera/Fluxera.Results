namespace Fluxera.Results.AspNetCore.Transformers
{
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	/// <summary>
	///		The default implementation with sane, opinionated transformation rules.
	/// </summary>
	[PublicAPI]
    public class DefaultActionResultTransformer : IActionResultTransformer
    {
        /// <inheritdoc />
        public IActionResult Transform(Result result)
        {
            return result.IsFailed
                ? this.TransformFailedResult(result)
                : this.TransformSuccessfulResult(result);
        }

        /// <inheritdoc />
        public IActionResult Transform<TValue>(Result<TValue> result)
        {
            return result.IsFailed
                ? this.TransformFailedResult(result)
                : this.TransformSuccessfulResult(result);
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="OkResult"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IActionResult TransformSuccessfulResult(Result result)
        {
            return new OkResult();
        }

        ///  <summary>
        /// 	Transforms the given result to a <see cref="OkResult"/>.
        ///  </summary>
        ///  <typeparam name="TValue"></typeparam>
        ///  <param name="result"></param>
        ///  <returns></returns>
        protected virtual IActionResult TransformSuccessfulResult<TValue>(Result<TValue> result)
        {
            return new OkObjectResult(result.GetValueOrDefault());
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="BadRequestObjectResult"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IActionResult TransformFailedResult(Result result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            return new BadRequestObjectResult(modelState);
        }

        ///  <summary>
        /// 	Transforms the given result to a <see cref="BadRequestObjectResult"/>.
        ///  </summary>
        ///  <typeparam name="TValue"></typeparam>
        ///  <param name="result"></param>
        ///  <returns></returns>
        protected virtual IActionResult TransformFailedResult<TValue>(Result<TValue> result)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();

            foreach (IError error in result.Errors)
            {
                modelState.AddModelError(string.Empty, error.Message);
            }

            return new BadRequestObjectResult(modelState);
        }
    }
}