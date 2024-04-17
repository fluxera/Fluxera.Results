namespace MadEyeMatt.Results.FluentAssertions
{
	using JetBrains.Annotations;
	using System;

	/// <summary>
	///		Should extension methods.
	/// </summary>
	[PublicAPI]
	public static class ResultExtensions
	{
		/// <summary>
		///		Should extension for <see cref="Result"/>.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static ResultAssertions Should(this Result result) 
		{
			if (result == null)
			{
				throw new ArgumentNullException(nameof(result));
			}

			return new ResultAssertions(result);
		}

		///  <summary>
		/// 		Should extension for <see cref="Result{TValue}"/>.
		///  </summary>
		///  <typeparam name="TValue"></typeparam>
		///  <param name="result"></param>
		///  <returns></returns>
		///  <exception cref="ArgumentNullException"></exception>
		public static ResultAssertions<TValue> Should<TValue>(this Result<TValue> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(nameof(result));
			}

			return new ResultAssertions<TValue>(result);
		}
	}
}