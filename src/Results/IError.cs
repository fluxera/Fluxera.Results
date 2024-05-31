namespace Fluxera.Results
{
	using System;
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
		///		Gets the (options) exception.
		/// </summary>
		Exception Exception { get; }

		/// <summary>
		///		Gets additional metadata of the error.
		/// </summary>
		IDictionary<string, object> Metadata { get; }

		/// <summary>
		///		Sets the message.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		IError WithMessage(string message);

		/// <summary>
		///		Sets the exception and the message from it.
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		IError WithException(Exception exception);

		/// <summary>
		///		Adds a metadata entry to the error.
		/// </summary>
		/// <param name="metadataKey"></param>
		/// <param name="metadataValue"></param>
		/// <returns></returns>
		IError WithMetadata(string metadataKey, string metadataValue);
	}
}