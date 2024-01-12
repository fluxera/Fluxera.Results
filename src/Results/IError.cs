namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///		A contract for error types.
	/// </summary>
	[PublicAPI]
	public interface IError
	{
		/// <summary>
		///		Gets the message of the error.
		/// </summary>
		string Message { get; }

		/// <summary>
		///		Gets additional metadata of the error.
		/// </summary>
		IDictionary<string, object> Metadata { get; }
	}
}