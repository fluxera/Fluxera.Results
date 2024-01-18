#if NET7_0_OR_GREATER
namespace MadEyeMatt.Results.AspNetCode
{
    using JetBrains.Annotations;
    using IHttpResult = Microsoft.AspNetCore.Http.IResult;

	/// <summary>
	///		A contract for transformer services that transform a <see cref="Result"/> to <see cref="IHttpResult"/>.
	/// </summary>
	[PublicAPI]
    public interface IHttpResultTransformer
    {
		/// <summary>
		///		Transforms the given result to <see cref="IHttpResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IHttpResult Transform(IResult result);

		/// <summary>
		///		Transforms the given result to <see cref="IHttpResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IHttpResult Transform<TValue>(IResult<TValue> result);
    }
}
#endif
