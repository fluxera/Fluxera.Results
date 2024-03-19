namespace MadEyeMatt.Results.AspNetCore
{
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
	///		A contract for transformer services that transform a <see cref="Result"/> to <see cref="IActionResult"/>.
	/// </summary>
	[PublicAPI]
	public interface IActionResultTransformer
	{
		/// <summary>
		///		Transforms the given result to <see cref="IActionResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IActionResult Transform(IResult result);

		/// <summary>
		///		Transforms the given result to <see cref="IActionResult"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		IActionResult Transform<TValue>(IResult<TValue> result);
	}
}