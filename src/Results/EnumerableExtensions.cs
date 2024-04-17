namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using System.Linq;
	using JetBrains.Annotations;

	/// <summary>
	///		Extension methods for the <see cref="IEnumerable{T}"/> type.
	/// </summary>
	[PublicAPI]
	public static class EnumerableExtensions
	{
		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		public static Result Merge(this IEnumerable<Result> results)
		{
			results ??= Enumerable.Empty<Result>();

			return Result.Merge(results.ToArray());
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		public static Result<IEnumerable<TValue>> Merge<TValue>(this IEnumerable<Result<TValue>> results)
		{
			results ??= Enumerable.Empty<Result<TValue>>();

			return Result.Merge(results.ToArray());
		}
	}
}