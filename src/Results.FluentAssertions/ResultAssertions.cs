namespace MadEyeMatt.Results.FluentAssertions
{
    using global::FluentAssertions;
    using global::FluentAssertions.Primitives;
    using JetBrains.Annotations;
    using System;
    using System.Linq;
    using global::FluentAssertions.Execution;

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
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsFailed)
                .ForCondition(isFailed => isFailed)
                .FailWith("Expected result to be failed, but is was successful");

            return new AndWhichConstraint<ResultAssertions<TResult>, ResultBase<TResult>>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult>, ResultBase<TResult>> BeSuccessful(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsSuccessful)
                .ForCondition(isSuccess => isSuccess)
                .FailWith("Expected result to be successful, but is was failed because of {0}", this.Subject.Errors);

            return new AndWhichConstraint<ResultAssertions<TResult>, ResultBase<TResult>>(this, this.Subject);
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
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Errors)
                .ForCondition(errors => errors.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain an error with message containing {0}, but found errors {1}", message, this.Subject.Errors);

            return new AndWhichThatConstraint<ResultAssertions<TResult>, ResultBase<TResult>, ErrorAssertions>(this, this.Subject, new ErrorAssertions(this.Subject.Errors.SingleOrDefault(reason => messageComparison(reason.Message, message))));
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
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Successes)
                .ForCondition(successes => successes.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain a success with message containing {0}, but found successes {1}", message, this.Subject.Successes);

            return new AndWhichThatConstraint<ResultAssertions<TResult>, ResultBase<TResult>, SuccessAssertions>(this, this.Subject, new SuccessAssertions(this.Subject.Successes.SingleOrDefault(reason => messageComparison(reason.Message, message))));
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
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsFailed)
                .ForCondition(isFailed => isFailed)
                .FailWith("Expected result to be failed, but is was successful");

            return new AndWhichConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>> BeSuccessful(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsSuccessful)
                .ForCondition(isSuccess => isSuccess)
                .FailWith("Expected result to be successful, but is was failed because of {0}", this.Subject.Errors);

            return new AndWhichConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>>(this, this.Subject);
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
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Errors)
                .ForCondition(errors => errors.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain an error with message containing {0}, but found errors {1}", message, this.Subject.Errors);

            return new AndWhichThatConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>, ErrorAssertions>(this, this.Subject, new ErrorAssertions(this.Subject.Errors.SingleOrDefault(reason => messageComparison(reason.Message, message))));
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
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Successes)
                .ForCondition(successes => successes.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain a success with message containing {0}, but found successes {1}", message, this.Subject.Successes);

            return new AndWhichThatConstraint<ResultAssertions<TResult, TValue>, ResultBase<TResult, TValue>, SuccessAssertions>(this, this.Subject, new SuccessAssertions(this.Subject.Successes.SingleOrDefault(reason => messageComparison(reason.Message, message))));
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
            Execute.Assertion
                .BecauseOf(because)
                .ForCondition(this.Subject.IsSuccessful)
                .FailWith("Value can not be asserted because the result is failed because of {0}", this.Subject.Errors)
                .Then
                .Given(() => this.Subject.Value)
                .ForCondition(actualValue => (actualValue == null && expectedValue == null) || actualValue.Equals(expectedValue))
                .FailWith("Expected value is {0}, but it is {1}", expectedValue, this.Subject.Value);

            return new AndConstraint<ResultAssertions<TResult, TValue>>(this);
		}
	}
}