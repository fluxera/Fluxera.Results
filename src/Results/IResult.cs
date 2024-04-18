namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
    using JetBrains.Annotations;

	/// <summary>
    ///		A contract for result types without value.
    /// </summary>
    [PublicAPI]
    public interface IResult
    {
		/// <summary>
		///		Flag, indicating that there is at least one error.
		/// </summary>
		bool IsFailed { get; }

		/// <summary>
		///		Flag, indicating that there are no errors.
		/// </summary>
		bool IsSuccessful { get; }

		/// <summary>
		///		Gets the existing errors.
		/// </summary>
		IList<IError> Errors { get; }

		/// <summary>
		///		Gets the existing successes.
		/// </summary>
		IList<ISuccess> Successes { get; }
	}

    /// <summary>
    ///		A contract for result types with value.
    /// </summary>
    [PublicAPI]
    public interface IResult<TValue> : IResult
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