namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;

	/// <summary>
	///		Extension methods for the <see cref="object"/> type.
	/// </summary>
	[PublicAPI]
	public static class ObjectExtensions
	{
		/// <summary>
		///		Creates a successful result for the value.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Result<TValue> ToResult<TValue>(this TValue value)
		{
			return Result.Ok(value);
		}
	}
}