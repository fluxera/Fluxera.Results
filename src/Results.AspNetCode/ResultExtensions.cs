namespace MadEyeMatt.Results.AspNetCode
{
	using System.Threading.Tasks;
	using JetBrains.Annotations;
    using MadEyeMatt.Results.AspNetCode.Transformers;
    using Microsoft.AspNetCore.Mvc;
    using IHttpResult = Microsoft.AspNetCore.Http.IResult;

	/// <summary>
	///		Extension methods for the results.
	/// </summary>
	[PublicAPI]
	public static class ResultExtensions
	{
		///  <summary>
		/// 		Converts the given <see cref="Result"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IActionResult ToActionResult(this IVoidResult result, IActionResultTransformer transformer = null)
		{
			transformer ??= new DefaultActionResultTransformer();

			return transformer.Transform(result);
		}

		///  <summary>
		/// 		Converts the given <see cref="Result"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IActionResult> ToActionResult<TResult>(this Task<TResult> resultTask, IActionResultTransformer transformer = null)
			where TResult : ResultBase<TResult>
		{
			TResult result = await resultTask;
			return result.ToActionResult(transformer);
		}

		///  <summary>
		/// 		Converts the given <see cref="Result{TValue}"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IActionResult ToActionResult<TValue>(this IValueResult<TValue> result, IActionResultTransformer transformer = null)
		{
			transformer ??= new DefaultActionResultTransformer();

			return transformer.Transform(result);
		}

		///  <summary>
		/// 		Converts the given <see cref="Result{TValue}"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IActionResult> ToActionResult<TResult, TValue>(this Task<TResult> resultTask, IActionResultTransformer transformer = null)
			where TResult : ResultBase<TResult, TValue>
		{
			TResult result = await resultTask;
			return result.ToActionResult(transformer);
		}

#if NET7_0_OR_GREATER
		///  <summary>
		/// 		Converts the given <see cref="Result"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IHttpResult ToHttpResult(this IVoidResult result, IHttpResultTransformer transformer = null)
        {
            transformer ??= new DefaultHttpResultTransformer();

            return transformer.Transform(result);
        }

		///  <summary>
		/// 		Converts the given <see cref="Result"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IHttpResult> ToHttpResult<TResult>(this Task<TResult> resultTask, IHttpResultTransformer transformer = null)
            where TResult : ResultBase<TResult>, IVoidResult
        {
            TResult result = await resultTask;
            return result.ToHttpResult(transformer);
        }

		///  <summary>
		/// 		Converts the given <see cref="Result{TValue}"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IHttpResult ToHttpResult<TValue>(this IValueResult<TValue> result, IHttpResultTransformer transformer = null)
        {
            transformer ??= new DefaultHttpResultTransformer();

            return transformer.Transform(result);
        }

        ///  <summary>
        /// 		Converts the given <see cref="Result{TValue}"/> to <see cref="IHttpResult"/>.
        ///  </summary>
        ///  <param name="resultTask"></param>
        ///  <param name="transformer"></param>
        ///  <returns></returns>
        public static async Task<IHttpResult> ToHttpResult<TResult, TValue>(this Task<TResult> resultTask, IHttpResultTransformer transformer = null)
            where TResult : ResultBase<TResult, TValue>, IValueResult<TValue>
        {
            TResult result = await resultTask;
            return result.ToHttpResult(transformer);
        }
#endif
	}
}
