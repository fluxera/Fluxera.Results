namespace MadEyeMatt.Results.FluentAssertions
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///		Should extension methods.
	/// </summary>
	[PublicAPI]
	public static class SuccessExtensions
	{
		/// <summary>
		///		Should extension for <see cref="IError"/>.
		/// </summary>
		/// <param name="success"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SuccessAssertions Should(this ISuccess success)
		{
			if (success == null) throw new ArgumentNullException(nameof(success));

			return new SuccessAssertions(success);
		}
	}
}