namespace MadEyeMatt.Results
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using JetBrains.Annotations;

	/// <summary>
	///		An abstract base class for result types.
	/// </summary>
	[PublicAPI]
	public abstract class ResultBase : IResult
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="ResultBase"/> type.
		/// </summary>
		protected ResultBase()
		{
			this.Errors = new List<IError>();
			this.Successes = new List<ISuccess>();
		}

		/// <inheritdoc />
		public bool IsFailed => this.Errors.Any();

		/// <inheritdoc />
		public bool IsSuccessful => !this.IsFailed;

		/// <inheritdoc />
		public IList<IError> Errors { get; }

		/// <inheritdoc />
		public IList<ISuccess> Successes { get; }

		/// <summary>
		///		Deconstructs the result.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="errors"></param>
		public void Deconstruct(out bool isSuccessful, out IList<IError> errors)
		{
			isSuccessful = this.IsSuccessful;
			errors = this.Errors;
		}

		/// <summary>
		///		Deconstructs the result.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="successes"></param>
		public void Deconstruct(out bool isSuccessful, out IList<ISuccess> successes)
		{
			isSuccessful = this.IsSuccessful;
			successes = this.Successes;
		}

		///  <summary>
		/// 		Deconstructs the result.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="errors"></param>
		///  <param name="successes"></param>
		public void Deconstruct(out bool isSuccessful, out IList<IError> errors, out IList<ISuccess> successes)
		{
			isSuccessful = this.IsSuccessful;
			errors = this.Errors;
			successes = this.Successes;
		}
	}

	/// <summary>
	///		An abstract base class for result types without a value.
	/// </summary>
	[PublicAPI]
	public abstract class ResultBase<TResult> : ResultBase
		where TResult : ResultBase<TResult>
	{
		/// <summary>
		///		Adds an error to the result.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public TResult WithError(IError error)
		{
			this.Errors.Add(error);
			return (TResult)this;
		}

		/// <summary>
		///		Adds an error message to the result.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public TResult WithError(string errorMessage)
		{
			return this.WithError(new Error(errorMessage));
		}

		/// <summary>
		///		Adds multiple successes to the result.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public TResult WithErrors(IEnumerable<IError> errors)
		{
			foreach (IError error in errors ?? Enumerable.Empty<IError>())
			{
				this.Errors.Add(error);
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds multiple error messages to the result.
		/// </summary>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public TResult WithErrors(IEnumerable<string> errorMessages)
		{
			foreach (string errorMessage in errorMessages ?? Enumerable.Empty<string>())
			{
				this.Errors.Add(new Error(errorMessage));
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds a success to the result.
		/// </summary>
		/// <param name="success"></param>
		/// <returns></returns>
		public TResult WithSuccess(ISuccess success)
		{
			this.Successes.Add(success);
			return (TResult)this;
		}

		/// <summary>
		///		Adds a success message to the result.
		/// </summary>
		/// <param name="successMessage"></param>
		/// <returns></returns>
		public TResult WithSuccess(string successMessage)
		{
			return this.WithSuccess(new Success(successMessage));
		}

		/// <summary>
		///		Adds multiple successes to the result.
		/// </summary>
		/// <param name="successes"></param>
		/// <returns></returns>
		public TResult WithSuccesses(IEnumerable<ISuccess> successes)
		{
			foreach (ISuccess success in successes ?? Enumerable.Empty<ISuccess>())
			{
				this.Successes.Add(success);
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds multiple success messages to the result.
		/// </summary>
		/// <param name="successMessages"></param>
		/// <returns></returns>
		public TResult WithSuccesses(IEnumerable<string> successMessages)
		{
			foreach (string successMessage in successMessages ?? Enumerable.Empty<string>())
			{
				this.Successes.Add(new Success(successMessage));
			}

			return (TResult)this;
		}
	}

	/// <summary>
	///		An abstract base class for result types with a value.
	/// </summary>
	[PublicAPI]
	public abstract class ResultBase<TResult, TValue> : ResultBase, IResult<TValue>
		where TResult : ResultBase<TResult, TValue>
	{
		private TValue currentValue;

		/// <inheritdoc />
		public TValue Value
		{
			get
			{
				this.ThrowIfFailed();

				return this.currentValue;
			}
			private set
			{
				this.ThrowIfFailed();

				this.currentValue = value;
			}
		}

		/// <inheritdoc />
		public TValue GetValueOrDefault(TValue defaultValue = default)
		{
			return this.currentValue.Equals(default) ? defaultValue : this.currentValue;
		}

		/// <summary>
		///		Sets the value of the result.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public TResult WithValue(TValue value)
		{
			this.Value = value;
			return (TResult)this;
		}

		/// <summary>
		///		Adds an error to the result.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public TResult WithError(IError error)
		{
			this.Errors.Add(error);
			return (TResult)this;
		}

		/// <summary>
		///		Adds an error message to the result.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public TResult WithError(string errorMessage)
		{
			return this.WithError(new Error(errorMessage));
		}

		/// <summary>
		///		Adds multiple successes to the result.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public TResult WithErrors(IEnumerable<IError> errors)
		{
			foreach (IError error in errors ?? Enumerable.Empty<IError>())
			{
				this.Errors.Add(error);
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds multiple error messages to the result.
		/// </summary>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public TResult WithErrors(IEnumerable<string> errorMessages)
		{
			foreach (string errorMessage in errorMessages ?? Enumerable.Empty<string>())
			{
				this.Errors.Add(new Error(errorMessage));
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds a success to the result.
		/// </summary>
		/// <param name="success"></param>
		/// <returns></returns>
		public TResult WithSuccess(ISuccess success)
		{
			this.Successes.Add(success);
			return (TResult)this;
		}

		/// <summary>
		///		Adds a success message to the result.
		/// </summary>
		/// <param name="successMessage"></param>
		/// <returns></returns>
		public TResult WithSuccess(string successMessage)
		{
			return this.WithSuccess(new Success(successMessage));
		}

		/// <summary>
		///		Adds multiple successes to the result.
		/// </summary>
		/// <param name="successes"></param>
		/// <returns></returns>
		public TResult WithSuccesses(IEnumerable<ISuccess> successes)
		{
			foreach (ISuccess success in successes ?? Enumerable.Empty<ISuccess>())
			{
				this.Successes.Add(success);
			}

			return (TResult)this;
		}

		/// <summary>
		///		Adds multiple success messages to the result.
		/// </summary>
		/// <param name="successMessages"></param>
		/// <returns></returns>
		public TResult WithSuccesses(IEnumerable<string> successMessages)
		{
			foreach (string successMessage in successMessages ?? Enumerable.Empty<string>())
			{
				this.Successes.Add(new Success(successMessage));
			}

			return (TResult)this;
		}

		///  <summary>
		/// 	Deconstructs the result.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		public void Deconstruct(out bool isSuccessful, out TValue value)
		{
			isSuccessful = this.IsSuccessful;
			value = this.IsSuccessful ? this.Value : default;
		}

		///  <summary>
		/// 	Deconstructs the result.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="errors"></param>
		public void Deconstruct(out bool isSuccessful, out TValue value, out IList<IError> errors)
		{
			isSuccessful = this.IsSuccessful;
			value = this.IsSuccessful ? this.Value : default;
			errors = this.Errors;
		}

		///  <summary>
		/// 	Deconstructs the result.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="successes"></param>
		public void Deconstruct(out bool isSuccessful, out TValue value, out IList<ISuccess> successes)
		{
			isSuccessful = this.IsSuccessful;
			value = this.IsSuccessful ? this.Value : default;
			successes = this.Successes;
		}

		///  <summary>
		/// 	Deconstructs the result.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="errors"></param>
		///  <param name="successes"></param>
		public void Deconstruct(out bool isSuccessful, out TValue value, out IList<IError> errors, out IList<ISuccess> successes)
		{
			isSuccessful = this.IsSuccessful;
			value = this.IsSuccessful ? this.Value : default;
			errors = this.Errors;
			successes = this.Successes;
		}

		private void ThrowIfFailed()
		{
			if (this.IsFailed)
			{
				throw new InvalidOperationException("The result is failed. The value is not set.");
			}
		}
	}
}