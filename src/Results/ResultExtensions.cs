namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	///		Extension methods for the <see cref="Result{T}"/> type.
	/// </summary>
	[PublicAPI]
	public static class ResultExtensions
	{
		///  <summary>
		/// 	Sets the value of the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="value"></param>
		///  <returns></returns>
		public static Result<TValue> WithValue<TValue>(this Result<TValue> result, TValue value)
		{
			result.Value = value;
			return result;
		}

		///  <summary>
		/// 	Adds an error to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result WithError(this Result result, IError error)
		{
			result.Errors.Add(error);
			return result;
		}

		///  <summary>
		/// 	Adds an error message to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result WithError(this Result result, string errorMessage)
		{
			return result.WithError(new Error(errorMessage));
		}

		///  <summary>
		/// 	Adds multiple errors to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errors"></param>
		///  <returns></returns>
		public static Result WithErrors(this Result result, IEnumerable<IError> errors)
		{
			foreach (IError error in errors ?? [])
			{
				result.Errors.Add(error);
			}

			return result;
		}

		///  <summary>
		/// 	Adds multiple error messages to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errorMessages"></param>
		///  <returns></returns>
		public static Result WithErrors(this Result result, IEnumerable<string> errorMessages)
		{
			foreach (string errorMessage in errorMessages ?? [])
			{
				result.Errors.Add(new Error(errorMessage));
			}

			return result;
		}

		///  <summary>
		/// 	Adds an error to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result<TValue> WithError<TValue>(this Result<TValue> result, IError error)
		{
			result.Errors.Add(error);
			return result;
		}

		///  <summary>
		/// 	Adds an error message to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result<TValue> WithError<TValue>(this Result<TValue> result, string errorMessage)
		{
			return result.WithError(new Error(errorMessage));
		}

		///  <summary>
		/// 	Adds multiple errors to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errors"></param>
		///  <returns></returns>
		public static Result<TValue> WithErrors<TValue>(this Result<TValue> result, IEnumerable<IError> errors)
		{
			foreach (IError error in errors ?? [])
			{
				result.Errors.Add(error);
			}

			return result;
		}

		///  <summary>
		/// 	Adds multiple error messages to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="errorMessages"></param>
		///  <returns></returns>
		public static Result<TValue> WithErrors<TValue>(this Result<TValue> result, IEnumerable<string> errorMessages)
		{
			foreach (string errorMessage in errorMessages ?? [])
			{
				result.Errors.Add(new Error(errorMessage));
			}

			return result;
		}

		///  <summary>
		/// 	Adds a success to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="success"></param>
		///  <returns></returns>
		public static Result WithSuccess(this Result result, ISuccess success)
		{
			result.Successes.Add(success);
			return result;
		}

		///  <summary>
		/// 	Adds a success message to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successMessage"></param>
		///  <returns></returns>
		public static Result WithSuccess(this Result result, string successMessage)
		{
			return result.WithSuccess(new Success(successMessage));
		}

		///  <summary>
		/// 	Adds multiple successes to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successes"></param>
		///  <returns></returns>
		public static Result WithSuccesses(this Result result, IEnumerable<ISuccess> successes)
		{
			foreach (ISuccess success in successes ?? [])
			{
				result.Successes.Add(success);
			}

			return result;
		}

		///  <summary>
		/// 	Adds multiple success messages to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successMessages"></param>
		///  <returns></returns>
		public static Result WithSuccesses(this Result result, IEnumerable<string> successMessages)
		{
			foreach (string successMessage in successMessages ?? [])
			{
				result.Successes.Add(new Success(successMessage));
			}

			return result;
		}





		///  <summary>
		/// 	Adds a success to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="success"></param>
		///  <returns></returns>
		public static Result<TValue> WithSuccess<TValue>(this Result<TValue> result, ISuccess success)
		{
			result.Successes.Add(success);
			return result;
		}

		///  <summary>
		/// 	Adds a success message to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successMessage"></param>
		///  <returns></returns>
		public static Result<TValue> WithSuccess<TValue>(this Result<TValue> result, string successMessage)
		{
			return result.WithSuccess(new Success(successMessage));
		}

		///  <summary>
		/// 	Adds multiple successes to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successes"></param>
		///  <returns></returns>
		public static Result<TValue> WithSuccesses<TValue>(this Result<TValue> result, IEnumerable<ISuccess> successes)
		{
			foreach (ISuccess success in successes ?? [])
			{
				result.Successes.Add(success);
			}

			return result;
		}

		///  <summary>
		/// 	Adds multiple success messages to the result.
		///  </summary>
		///  <param name="result"></param>
		///  <param name="successMessages"></param>
		///  <returns></returns>
		public static Result<TValue> WithSuccesses<TValue>(this Result<TValue> result, IEnumerable<string> successMessages)
		{
			foreach (string successMessage in successMessages ?? [])
			{
				result.Successes.Add(new Success(successMessage));
			}

			return result;
		}
	}
}
