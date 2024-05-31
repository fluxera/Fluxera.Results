namespace Fluxera.Results
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

		/// <summary>
		///		Sets the message.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		ISuccess WithMessage(string message);

		/// <summary>
		///		Adds a metadata entry to the error.
		/// </summary>
		/// <param name="metadataKey"></param>
		/// <param name="metadataValue"></param>
		/// <returns></returns>
		ISuccess WithMetadata(string metadataKey, string metadataValue);
	}
}