#if NET7_0_OR_GREATER
namespace MadEyeMatt.Results.AspNetCore
{
    using JetBrains.Annotations;
	using Microsoft.AspNetCore.Http;

	/// <summary>
	///		A contract for transformer services that transform a <see cref="Result"/> to <see cref="IResult"/>.
	/// </summary>
	[PublicAPI]
    public interface IHttpResultTransformer
    {
		/// <summary>
		///		Transforms the given result to <see cref="IResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IResult Transform(Result result);

		/// <summary>
		///		Transforms the given result to <see cref="IResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IResult Transform<TValue>(Result<TValue> result);
    }
}
#endif
