namespace MadEyeMatt.Results
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///		A default and base error implementation.
	/// </summary>
	[PublicAPI]
	public class Error : IError
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
		public Exception Exception { get; private set; }

		/// <inheritdoc />
		public IDictionary<string, object> Metadata { get; }

		/// <inheritdoc />
		public IError WithMessage(string message)
		{
			this.Message = message;
			return this;
		}

		/// <inheritdoc />
		public IError WithException(Exception exception)
		{
			this.Exception = exception;
			return this;
		}

		/// <inheritdoc />
		public IError WithMetadata(string metadataKey, string metadataValue)
		{
			this.Metadata.Add(metadataKey, metadataValue);
			return this;
		}
	}
}