namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///		A contract for success types.
	/// </summary>
	[PublicAPI]
	public interface ISuccess
	{
		/// <summary>
		///		Gets the message of the success.
		/// </summary>
		string Message { get; }

		/// <summary>
		///		Gets additional metadata of the success.
		/// </summary>
		IDictionary<string, object> Metadata { get; }
	}
}