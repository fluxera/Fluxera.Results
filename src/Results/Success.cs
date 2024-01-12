namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;
	using System.Collections.Generic;

	/// <summary>
	///		A default success implementation.
	/// </summary>
	[PublicAPI]
	public sealed class Success : ISuccess
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="Success"/> type.
		/// </summary>
		public Success()
		{
			this.Metadata = new Dictionary<string, object>();
		}

		/// <summary>
		///		Initializes a new instance of the <see cref="Success"/> type.
		/// </summary>
		/// <param name="message"></param>
		public Success(string message) : this()
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
		public Success WithMessage(string message)
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
		public Success WithMetadata(string metadataKey, string metadataValue)
		{
			this.Metadata.Add(metadataKey, metadataValue);
			return this;
		}
	}
}