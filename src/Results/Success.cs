namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;
	using System.Collections.Generic;

	/// <summary>
	///		A default ans base success implementation.
	/// </summary>
	[PublicAPI]
	public class Success : ISuccess
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


		/// <inheritdoc />
		public ISuccess WithMessage(string message)
		{
			this.Message = message;
			return this;
		}

		/// <inheritdoc />
		public ISuccess WithMetadata(string metadataKey, string metadataValue)
		{
			this.Metadata.Add(metadataKey, metadataValue);
			return this;
		}
	}
}