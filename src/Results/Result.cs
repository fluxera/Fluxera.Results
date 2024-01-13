namespace MadEyeMatt.Results
{
	using JetBrains.Annotations;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	///		A default result type without a value.
	/// </summary>
	[PublicAPI]
	public sealed class Result : ResultBase<Result>
	{
		/// <summary>
		///		Creates a successful result.
		/// </summary>
		/// <returns></returns>
		public static Result Ok()
		{
			return Ok<Result>();
		}

		/// <summary>
		///		Creates a successful result.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <returns></returns>
		public static TResult Ok<TResult>() where TResult : ResultBase<TResult>, new()
		{
			return new TResult();
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result OkIf(bool isSuccessful, IError error)
		{
			return OkIf<Result>(isSuccessful, error);
		}

		/// <summary>
		///		Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="isSuccessful"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static TResult OkIf<TResult>(bool isSuccessful, IError error) where TResult : ResultBase<TResult>, new()
		{
			return isSuccessful ? Ok<TResult>() : Fail<TResult>(error);
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result OkIf(bool isSuccessful, string errorMessage)
		{
			return OkIf<Result>(isSuccessful, errorMessage);
		}

		/// <summary>
		///		Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="isSuccessful"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static TResult OkIf<TResult>(bool isSuccessful, string errorMessage) where TResult : ResultBase<TResult>, new()
		{
			return isSuccessful ? Ok<TResult>() : Fail<TResult>(errorMessage);
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result Fail(IError error)
		{
			return Fail<Result>(error);
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="error"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IError error) where TResult : ResultBase<TResult>, new()
		{
			TResult result = new TResult();
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
			return Fail<Result>(errorMessage);
		}

		/// <summary>
		///		Creates a failed result with the given error message.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(string errorMessage) where TResult : ResultBase<TResult>, new()
		{
			TResult result = new TResult();
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
			return Fail<Result>(errors);
		}

		/// <summary>
		///		Creates a failed result with the given errors.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IEnumerable<IError> errors) where TResult : ResultBase<TResult>, new()
		{
			TResult result = new TResult();
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
			return Fail<Result>(errorMessages);
		}

		/// <summary>
		///		Creates a failed result with the given error messages.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IEnumerable<string> errorMessages) where TResult : ResultBase<TResult>, new()
		{
			TResult result = new TResult();
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
			return FailIf<Result>(isFailure, error);
		}

		/// <summary>
		///		Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="isFailure"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static TResult FailIf<TResult>(bool isFailure, IError error) where TResult : ResultBase<TResult>, new()
		{
			return isFailure ? Fail<TResult>(error) : Ok<TResult>();
		}

		/// <summary>
		///		 Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		/// </summary>
		/// <param name="isFailure"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result FailIf(bool isFailure, string errorMessage)
		{
			return FailIf<Result>(isFailure, errorMessage);
		}

		/// <summary>
		///		Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="isFailure"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static TResult FailIf<TResult>(bool isFailure, string errorMessage) where TResult : ResultBase<TResult>, new()
		{
			return isFailure ? Fail<TResult>(errorMessage) : Ok<TResult>();
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Result Merge(params Result[] results)
		{
			return Merge<Result>(results);
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static TResult Merge<TResult>(params TResult[] results) where TResult : ResultBase<TResult>, new()
		{
			TResult result = new TResult();
			result.WithErrors(results.SelectMany(x => x.Errors));
			result.WithSuccesses(results.SelectMany(x => x.Successes));
			return result;
		}

		/// <summary>
		///		Batches multiple results into one batch result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static BatchResult<Result> Batch(params Result[] results)
		{
			return Batch<Result>(results);
		}

		/// <summary>
		///		Batches multiple results into one batch result.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="results"></param>
		/// <returns></returns>
		public static BatchResult<TResult> Batch<TResult>(params TResult[] results) where TResult : ResultBase<TResult>, new()
		{
			BatchResult<TResult> result = new BatchResult<TResult>();
			result.WithResults(results);
			return result;
		}
	}

	/// <summary>
	///		A default result type with a value.
	/// </summary>
	[PublicAPI]
	public sealed class Result<TValue> : ResultBase<Result<TValue>, TValue>
	{
		/// <summary>
		///		Converts the result with value to result without value.
		/// </summary>
		/// <returns></returns>
		public Result ToResult()
		{
			return new Result().WithErrors(this.Errors);
		}

		/// <summary>
		///		Creates a successful result with the given value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Result<TValue> Ok(TValue value)
		{
			return Ok<Result<TValue>>(value);
		}

		/// <summary>
		///		Creates a successful result with the given value.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static TResult Ok<TResult>(TValue value) where TResult : ResultBase<TResult, TValue>, new()
		{
			TResult result = new TResult();
			result.WithValue(value);
			return result;
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result<TValue> OkIf(bool isSuccessful, TValue value, IError error)
		{
			return OkIf<Result<TValue>>(isSuccessful, value, error);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <typeparam name="TResult"></typeparam>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static TResult OkIf<TResult>(bool isSuccessful, TValue value, IError error) where TResult : ResultBase<TResult, TValue>, new()
		{
			return isSuccessful ? Ok<TResult>(value) : Fail<TResult>(error);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result<TValue> OkIf(bool isSuccessful, TValue value, string errorMessage)
		{
			return OkIf<Result<TValue>>(isSuccessful, value, errorMessage);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isSuccessful"/>.
		///  </summary>
		///  <typeparam name="TResult"></typeparam>
		///  <param name="isSuccessful"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static TResult OkIf<TResult>(bool isSuccessful, TValue value, string errorMessage) where TResult : ResultBase<TResult, TValue>, new()
		{
			return isSuccessful ? Ok<TResult>(value) : Fail<TResult>(errorMessage);
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <param name="error"></param>
		/// <returns></returns>
		public static Result<TValue> Fail(IError error)
		{
			return Fail<Result<TValue>>(error);
		}

		/// <summary>
		///		Creates a failed result with the given error.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="error"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IError error) where TResult : ResultBase<TResult, TValue>, new()
		{
			TResult result = new TResult();
			result.WithError(error);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error message.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result<TValue> Fail(string errorMessage)
		{
			return Fail<Result<TValue>>(errorMessage);
		}

		/// <summary>
		///		Creates a failed result with the given error message.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(string errorMessage) where TResult : ResultBase<TResult, TValue>, new()
		{
			TResult result = new TResult();
			result.WithError(errorMessage);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given errors.
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static Result<TValue> Fail(IEnumerable<IError> errors)
		{
			return Fail<Result<TValue>>(errors);
		}

		/// <summary>
		///		Creates a failed result with the given errors.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errors"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IEnumerable<IError> errors) where TResult : ResultBase<TResult, TValue>, new()
		{
			TResult result = new TResult();
			result.WithErrors(errors);
			return result;
		}

		/// <summary>
		///		Creates a failed result with the given error messages.
		/// </summary>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public static Result<TValue> Fail(IEnumerable<string> errorMessages)
		{
			return Fail<Result<TValue>>(errorMessages);
		}

		/// <summary>
		///		Creates a failed result with the given error messages.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="errorMessages"></param>
		/// <returns></returns>
		public static TResult Fail<TResult>(IEnumerable<string> errorMessages) where TResult : ResultBase<TResult, TValue>, new()
		{
			TResult result = new TResult();
			result.WithErrors(errorMessages);
			return result;
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static Result<TValue> FailIf(bool isFailure, TValue value, IError error)
		{
			return FailIf<Result<TValue>>(isFailure, value, error);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <typeparam name="TResult"></typeparam>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="error"></param>
		///  <returns></returns>
		public static TResult FailIf<TResult>(bool isFailure, TValue value, IError error) where TResult : ResultBase<TResult, TValue>, new()
		{
			return isFailure ? Fail<TResult>(error) : Ok<TResult>(value);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static Result<TValue> FailIf(bool isFailure, TValue value, string errorMessage)
		{
			return FailIf<Result<TValue>>(isFailure, value, errorMessage);
		}

		///  <summary>
		/// 	Create a successful or a failed result depending on the parameter <paramref name="isFailure"/>.
		///  </summary>
		///  <typeparam name="TResult"></typeparam>
		///  <param name="isFailure"></param>
		///  <param name="value"></param>
		///  <param name="errorMessage"></param>
		///  <returns></returns>
		public static TResult FailIf<TResult>(bool isFailure, TValue value, string errorMessage) where TResult : ResultBase<TResult, TValue>, new()
		{
			return isFailure ? Fail<TResult>(errorMessage) : Ok<TResult>(value);
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Result<IEnumerable<TValue>> Merge(params Result<TValue>[] results)
		{
			return Merge<Result<TValue>>(results);
		}

		/// <summary>
		///		Merge multiple results into one single result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Result<IEnumerable<TValue>> Merge<TResult>(params TResult[] results) where TResult : ResultBase<TResult, TValue>, new()
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

		/// <summary>
		///		Batches multiple results into one batch result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public static BatchResult<Result<TValue>> Batch(params Result<TValue>[] results)
		{
			return Batch<Result<TValue>>(results);
		}

		/// <summary>
		///		Batches multiple results into one batch result.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="results"></param>
		/// <returns></returns>
		public static BatchResult<TResult> Batch<TResult>(params TResult[] results) where TResult : ResultBase<TResult, TValue>, new()
		{
			BatchResult<TResult> result = new BatchResult<TResult>();
			result.WithResults(results);
			return result;
		}
	}
}