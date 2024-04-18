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
	public sealed class ResultAssertions : ReferenceTypeAssertions<Result, ResultAssertions>
	{ 
		static ResultAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public ResultAssertions(Result subject)
			: base(subject)
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(Result);

		/// <summary>
		///		Asserts if the result was failed.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions, Result> BeFailed(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsFailed)
                .ForCondition(isFailed => isFailed)
                .FailWith("Expected result to be failed, but is was successful");

            return new AndWhichConstraint<ResultAssertions, Result>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions, Result> BeSuccessful(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsSuccessful)
                .ForCondition(isSuccess => isSuccess)
                .FailWith("Expected result to be successful, but is was failed because of {0}", this.Subject.Errors);

            return new AndWhichConstraint<ResultAssertions, Result>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result has an error with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions, Result, ErrorAssertions> HaveError(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Errors)
                .ForCondition(errors => errors.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain an error with message containing {0}, but found errors {1}", message, this.Subject.Errors);

            return new AndWhichThatConstraint<ResultAssertions, Result, ErrorAssertions>(this, this.Subject, new ErrorAssertions(this.Subject.Errors.SingleOrDefault(reason => messageComparison(reason.Message, message))));
		}

		/// <summary>
		///		Asserts if the result has a success with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions, Result, SuccessAssertions> HaveSuccess(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Successes)
                .ForCondition(successes => successes.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain a success with message containing {0}, but found successes {1}", message, this.Subject.Successes);

            return new AndWhichThatConstraint<ResultAssertions, Result, SuccessAssertions>(this, this.Subject, new SuccessAssertions(this.Subject.Successes.SingleOrDefault(reason => messageComparison(reason.Message, message))));
		}
	}

	///  <summary>
	/// 	Assertions for the <see cref="Result{TValue}"/> type.
	///  </summary>
	///  <typeparam name="TValue"></typeparam>
	[PublicAPI]
	public sealed class ResultAssertions<TValue> : ReferenceTypeAssertions<Result<TValue>, ResultAssertions<TValue>>
	{
		static ResultAssertions()
		{
			ResultFormatters.Register();
		}

		/// <inheritdoc />
		public ResultAssertions(Result<TValue> subject)
			: base(subject)
		{
		}

		/// <inheritdoc />
		protected override string Identifier => nameof(Result);

		/// <summary>
		///		Asserts if the result was failed.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TValue>, Result<TValue>> BeFailed(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsFailed)
                .ForCondition(isFailed => isFailed)
                .FailWith("Expected result to be failed, but is was successful");

            return new AndWhichConstraint<ResultAssertions<TValue>, Result<TValue>>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result was successful.
		/// </summary>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichConstraint<ResultAssertions<TValue>, Result<TValue>> BeSuccessful(string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.IsSuccessful)
                .ForCondition(isSuccess => isSuccess)
                .FailWith("Expected result to be successful, but is was failed because of {0}", this.Subject.Errors);

            return new AndWhichConstraint<ResultAssertions<TValue>, Result<TValue>>(this, this.Subject);
		}

		/// <summary>
		///		Asserts if the result has an error with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TValue>, Result<TValue>, ErrorAssertions> HaveError(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Errors)
                .ForCondition(errors => errors.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain an error with message containing {0}, but found errors {1}", message, this.Subject.Errors);

            return new AndWhichThatConstraint<ResultAssertions<TValue>, Result<TValue>, ErrorAssertions>(this, this.Subject, new ErrorAssertions(this.Subject.Errors.SingleOrDefault(reason => messageComparison(reason.Message, message))));
		}

		/// <summary>
		///		Asserts if the result has a success with given message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="messageComparison"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndWhichThatConstraint<ResultAssertions<TValue>, Result<TValue>, SuccessAssertions> HaveSuccess(string message, Func<string, string, bool> messageComparison = null, string because = "", params object[] becauseArgs)
		{
            messageComparison ??= MessageComparison.Equal;

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => this.Subject.Successes)
                .ForCondition(successes => successes.Any(error => messageComparison(error.Message, message)))
                .FailWith("Expected result to contain a success with message containing {0}, but found successes {1}", message, this.Subject.Successes);

            return new AndWhichThatConstraint<ResultAssertions<TValue>, Result<TValue>, SuccessAssertions>(this, this.Subject, new SuccessAssertions(this.Subject.Successes.SingleOrDefault(reason => messageComparison(reason.Message, message))));
		}

		/// <summary>
		///		Asserts if the result has the expected value.
		/// </summary>
		/// <param name="expectedValue"></param>
		/// <param name="because"></param>
		/// <param name="becauseArgs"></param>
		/// <returns></returns>
		public AndConstraint<ResultAssertions<TValue>> HaveValue(TValue expectedValue, string because = "", params object[] becauseArgs)
		{
            Execute.Assertion
                .BecauseOf(because)
                .ForCondition(this.Subject.IsSuccessful)
                .FailWith("Value can not be asserted because the result is failed because of {0}", this.Subject.Errors)
                .Then
                .Given(() => this.Subject.Value)
                .ForCondition(actualValue => (actualValue == null && expectedValue == null) || actualValue.Equals(expectedValue))
                .FailWith("Expected value is {0}, but it is {1}", expectedValue, this.Subject.Value);

            return new AndConstraint<ResultAssertions<TValue>>(this);
		}
	}
}