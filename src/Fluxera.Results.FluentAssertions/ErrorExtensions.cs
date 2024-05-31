namespace Fluxera.Results.FluentAssertions
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
	///		Should extension methods.
	/// </summary>
	[PublicAPI]
	public static class ErrorExtensions
	{
		/// <summary>
		///		Should extension for <see cref="IError"/>.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static ErrorAssertions Should(this IError error)
		{
			if (error == null)
			{
				throw new ArgumentNullException(nameof(error));
			}

			return new ErrorAssertions(error);
		}
	}
}