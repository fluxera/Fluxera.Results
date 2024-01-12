namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///		A default error implementation.
	/// </summary>
	[PublicAPI]
	public sealed class Error : IError
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="Error"/> type.
		/// </summary>
		public Error()
		{
			this.Metadata = new Dictionary<string, object>();
		}

		/// <summary>
		///		Initializes a new instance of the <see cref="Error"/> type.
		/// </summary>
		/// <param name="message"></param>
		public Error(string message) : this()
		{
			this.Message = message;
		}

		/// <inheritdoc />
		public string Message { get; private set; }

		/// <inheritdoc />
		public IDictionary<string, object> Metadata { get; }

		/// <summary>
		///		Sets the message.
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public Error WithMessage(string message)
		{
			this.Message = message;
			return this;
		}

		/// <summary>
		///		Adds a metadata entry to the error.
		/// </summary>
		/// <param name="metadataKey"></param>
		/// <param name="metadataValue"></param>
		/// <returns></returns>
		public Error WithMetadata(string metadataKey, string metadataValue)
		{
			this.Metadata.Add(metadataKey, metadataValue);
			return this;
		}
	}
}