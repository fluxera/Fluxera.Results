namespace MadEyeMatt.Results.AspNetCode.Transformers
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
        public IActionResult Transform(IVoidResult result)
        {
            return result.IsFailed
                ? this.TransformFailedResult(result)
                : this.TransformSuccessfulResult(result);
        }

        /// <inheritdoc />
        public IActionResult Transform<TValue>(IValueResult<TValue> result)
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
        protected virtual IActionResult TransformSuccessfulResult(IVoidResult result)
        {
            return new OkResult();
        }

        ///  <summary>
        /// 	Transforms the given result to a <see cref="OkResult"/>.
        ///  </summary>
        ///  <typeparam name="TValue"></typeparam>
        ///  <param name="result"></param>
        ///  <returns></returns>
        protected virtual IActionResult TransformSuccessfulResult<TValue>(IValueResult<TValue> result)
        {
            return new OkObjectResult(result.GetValueOrDefault());
        }

        /// <summary>
        ///		Transforms the given result to a <see cref="BadRequestObjectResult"/>.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IActionResult TransformFailedResult(IVoidResult result)
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
        protected virtual IActionResult TransformFailedResult<TValue>(IValueResult<TValue> result)
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