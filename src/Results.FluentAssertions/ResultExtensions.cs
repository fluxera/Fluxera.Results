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
		///  <typeparam name="TResult"></typeparam>
		/// <param name="result"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static ResultAssertions<TResult> Should<TResult>(this ResultBase<TResult> result) 
			where TResult : ResultBase<TResult>
		{
			if (result == null) throw new ArgumentNullException(nameof(result));

			return new ResultAssertions<TResult>(result);
		}

		///  <summary>
		/// 		Should extension for <see cref="Result{TValue}"/>.
		///  </summary>
		///  <typeparam name="TResult"></typeparam>
		///  <typeparam name="TValue"></typeparam>
		///  <param name="result"></param>
		///  <returns></returns>
		///  <exception cref="ArgumentNullException"></exception>
		public static ResultAssertions<TResult, TValue> Should<TResult, TValue>(this ResultBase<TResult, TValue> result)
			where TResult : ResultBase<TResult, TValue>
		{
			if (result == null) throw new ArgumentNullException(nameof(result));

			return new ResultAssertions<TResult, TValue>(result);
		}
	}
}