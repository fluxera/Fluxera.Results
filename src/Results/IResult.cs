namespace MadEyeMatt.Results
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    /// <summary>
    ///		A contract for result types.
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
}