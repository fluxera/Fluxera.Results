namespace MadEyeMatt.Results.FluentAssertions
{
    using global::FluentAssertions;
    using global::FluentAssertions.Primitives;
    using JetBrains.Annotations;
    using MadEyeMatt.Results.FluentAssertions.Assertions;
	using System;

	/// <summary>
	///		Assertions for the <see cref="Result"/> type.
	/// </summary>
    [PublicAPI]
	public sealed class ResultAssertions<TResult> : ReferenceTypeAssertions<ResultBase<TResult>, ResultAssertions<TResult>>
		where TResult : ResultBase<TResult>
	{ 
		static ResultAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public ResultAssertions(ResultBase<TResult> subject)
			: base(subject)
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(TResult);

		/// <summary>
		///		Asserts if the result was failed.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult>, ResultBase<TResult>> BeFailed(string because = "", params object[] becauseArgs)
		{
			return BeFailedAssertion.Do(this.Subject, this, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult>, ResultBase<TResult>> BeSuccessful(string because = "", params object[] becauseArgs)
		{
			return BeSuccessfulAssertion.Do(this.Subject, this, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result has an error with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TResult>, ResultBase<TResult>, ErrorAssertions> HaveError(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
			return HaveErrorAssertion.Do(this.Subject, this, message, messageComparison, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result has a success with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TResult>, ResultBase<TResult>, SuccessAssertions> HaveSuccess(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
			return HaveSuccessAssertion.Do(this.Subject, this, message, messageComparison, because, becauseArgs);
		}
	}

	///  <summary>
	/// 	Assertions for the <see cref="Result{TValue}"/> type.
	///  </summary>
	///  <typeparam name="TValue"></typeparam>
	///  <typeparam name="TResult"></typeparam>
	[PublicAPI]
	public sealed class ResultAssertions<TResult, TValue> : ReferenceTypeAssertions<ResultBase<TResult, TValue>, ResultAssertions<TResult, TValue>>
		where TResult : ResultBase<TResult, TValue>
	{
		static ResultAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public ResultAssertions(ResultBase<TResult, TValue> subject)
			: base(subject)
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(TResult);

		/// <summary>
		///		Asserts if the result was failed.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>> BeFailed(string because = "", params object[] becauseArgs)
		{
			return BeFailedAssertion.Do(this.Subject, this, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>> BeSuccessful(string because = "", params object[] becauseArgs)
		{
			return BeSuccessfulAssertion.Do(this.Subject, this, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result has an error with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>, ErrorAssertions> HaveError(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
			return HaveErrorAssertion.Do(this.Subject, this, message, messageComparison, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result has a success with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>, SuccessAssertions> HaveSuccess(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
			return HaveSuccessAssertion.Do(this.Subject, this, message, messageComparison, because, becauseArgs);
		}

		/// <summary>
		///		Asserts if the result has the expected value.
		/// </summary>
		/// <param name="expectedValue"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndConstraint<ResultAssertions<TResult, TValue>> HaveValue(TValue expectedValue, string because = "", params object[] becauseArgs)
		{
			return HaveValueAssertion.Do(this.Subject, this, expectedValue, because, becauseArgs);
		}
	}
}