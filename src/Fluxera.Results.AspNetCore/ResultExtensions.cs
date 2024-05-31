namespace Fluxera.Results.AspNetCore
{
	using System.Threading.Tasks;
	using Fluxera.Results.AspNetCore.Transformers;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	///		Extension methods for the results.
	/// </summary>
	[PublicAPI]
	public static class ResultExtensions
	{
		///  <summary>
		/// 	Converts the given <see cref="Result"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IActionResult ToActionResult(this Result result, IActionResultTransformer transformer = null)
		{
			transformer ??= new DefaultActionResultTransformer();

			return transformer.Transform(result);
		}

		///  <summary>
		/// 	Converts the given <see cref="Result"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IActionResult> ToActionResult(this Task<Result> resultTask, IActionResultTransformer transformer = null)
		{
			Result result = await resultTask;
			return result.ToActionResult(transformer);
		}

		///  <summary>
		/// 	Converts the given <see cref="Result{TValue}"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IActionResult ToActionResult<TValue>(this Result<TValue> result, IActionResultTransformer transformer = null)
		{
			transformer ??= new DefaultActionResultTransformer();

			return transformer.Transform(result);
		}

		///  <summary>
		/// 	Converts the given <see cref="Result{TValue}"/> to <see cref="IActionResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IActionResult> ToActionResult<TValue>(this Task<Result<TValue>> resultTask, IActionResultTransformer transformer = null)
		{
			Result<TValue> result = await resultTask;
			return result.ToActionResult(transformer);
		}

#if NET7_0_OR_GREATER
		///  <summary>
		/// 	Converts the given <see cref="Result"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IResult ToHttpResult(this Result result, IHttpResultTransformer transformer = null)
        {
            transformer ??= new DefaultHttpResultTransformer();

            return transformer.Transform(result);
        }

		///  <summary>
		/// 	Converts the given <see cref="Result"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IResult> ToHttpResult(this Task<Result> resultTask, IHttpResultTransformer transformer = null)
		{
			Result result = await resultTask;
			return result.ToHttpResult(transformer);
		}

		///  <summary>
		/// 	Converts the given <see cref="Result"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="resultTask"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static async Task<IResult> ToHttpResult<TValue>(this Task<Result<TValue>> resultTask, IHttpResultTransformer transformer = null)
        {
			transformer ??= new DefaultHttpResultTransformer();

			Result<TValue> result = await resultTask;
            return result.ToHttpResult(transformer);
        }

		///  <summary>
		/// 		Converts the given <see cref="Result{TValue}"/> to <see cref="IHttpResult"/>.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="transformer"></param>
		///  <returns></returns>
		public static IResult ToHttpResult<TValue>(this Result<TValue> result, IHttpResultTransformer transformer = null)
        {
            transformer ??= new DefaultHttpResultTransformer();

            return transformer.Transform(result);
        }
#endif
	}
}
