namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	///		A default result type without a value.
	/// </summary>
	[PublicAPI]
	public class Result : Result<Unit>
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="Result"/> type.
		/// </summary>
		public Result()
		{
			this.WithValue(new Unit());
		}

		/// <summary>
		///		Creates a successful result.
		/// </summary>
		/// <returns></returns>
		public static Result Ok()
		{
			return new Result();
		}

		/// <summary>
		///		Creates a successful result with the given value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Result<TValue> Ok<TValue>(TValue value)
		{
			return new Result<TValue>().WithValue(value);
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result OkIf(bool isSuccessful, IError error)
		{
			return isSuccessful ? Ok() : Fail(error);
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result OkIf(bool isSuccessful, string errorMessage)
		{
			return isSuccessful ? Ok() : Fail(errorMessage);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result<TValue> OkIf<TValue>(bool isSuccessful, TValue value, IError error)
		{
			return isSuccessful ? Ok(value) : Fail<TValue>(error);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result<TValue> OkIf<TValue>(bool isSuccessful, TValue value, string errorMessage)
		{
			return isSuccessful ? Ok(value) : Fail<TValue>(errorMessage);
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result Fail(IError error)
		{
			Result result = new Result();
			result.WithError(error);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error message.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result Fail(string errorMessage)
		{
			Result result = new Result();
			result.WithError(errorMessage);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given errors.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static Result Fail(IEnumerable<IError> errors)
		{
			Result result = new Result();
			result.WithErrors(errors);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error messages.
		/// </summary>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public static Result Fail(IEnumerable<string> errorMessages)
		{
			Result result = new Result();
			result.WithErrors(errorMessages);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result<TValue> Fail<TValue>(IError error)
		{
			Result<TValue> result = new Result<TValue>();
			result.WithError(error);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error message.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result<TValue> Fail<TValue>(string errorMessage)
		{
			Result<TValue> result = new Result<TValue>();
			result.WithError(errorMessage);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given errors.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static Result<TValue> Fail<TValue>(IEnumerable<IError> errors)
		{
			Result<TValue> result = new Result<TValue>();
			result.WithErrors(errors);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error messages.
		/// </summary>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public static Result<TValue> Fail<TValue>(IEnumerable<string> errorMessages)
		{
			Result<TValue> result = new Result<TValue>();
			result.WithErrors(errorMessages);
			return result;
		}

		/// <summary>
		///		Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		/// </summary>
		/// <param name="isFailure"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result FailIf(bool isFailure, IError error)
		{
			return isFailure ? Fail(error) : Ok();
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		/// </summary>
		/// <param name="isFailure"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result FailIf(bool isFailure, string errorMessage)
		{
			return isFailure ? Fail(errorMessage) : Ok();
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result<TValue> FailIf<TValue>(bool isFailure, TValue value, IError error)
		{
			return isFailure ? Fail<TValue>(error) : Ok(value);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result<TValue> FailIf<TValue>(bool isFailure, TValue value, string errorMessage)
		{
			return isFailure ? Fail<TValue>(errorMessage) : Ok(value);
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Result Merge(params Result[] results)
		{
			Result result = new Result();
			result.WithErrors(results.SelectMany(x => x.Errors));
			result.WithSuccesses(results.SelectMany(x => x.Successes));
			return result;
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Result<IEnumerable<TValue>> Merge<TValue>(params Result<TValue>[] results)
		{
			Result<IEnumerable<TValue>> result = new Result<IEnumerable<TValue>>();
			result.WithErrors(results.SelectMany(x => x.Errors));
			result.WithSuccesses(results.SelectMany(x => x.Successes));

			if (result.IsSuccessful)
			{
				result.WithValue(results.Select(x => x.Value));
			}

			return result;
		}
	}

	/// <summary>
	///		A default result type with a value.
	/// </summary>
	[PublicAPI]
	public class Result<TValue> : IResult<TValue>
	{
		private TValue currentValue;

		/// <summary>
		///		Initializes a new instance of the <see cref="Result{TValue}"/> type.
		/// </summary>
		public Result()
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

		/// <inheritdoc />
		public TValue Value
		{
			get
			{
				this.ThrowIfFailed();

				return this.currentValue;
			}
			internal set
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