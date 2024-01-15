namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;

    /// <summary>
	///		A contract for result types with a value.
	/// </summary>
	[PublicAPI]
	public interface IValueResult<TValue> : IResult
	{
		/// <summary>
		///		Gets the value.
		/// </summary>
		/// <remarks>
		///		If the result is failed, an exception is thrown, because a failed result has no value.
		/// </remarks>
		TValue Value { get; }

		/// <summary>
		///		Gets the value or its default value.
		/// </summary>
		/// <remarks>
		///		If the result is failed, the default value is returned.
		/// </remarks>
		/// <returns></returns>
		TValue GetValueOrDefault(TValue defaultValue = default);
	}
}