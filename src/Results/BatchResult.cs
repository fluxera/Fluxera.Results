namespace MadEyeMatt.Results
{
	using System.Collections.Generic;
	using System.Linq;
	using JetBrains.Annotations;

	/// <summary>
	///		A result that aggregates multiple results.
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	[PublicAPI]
	public sealed class BatchResult<TResult> : IResult where TResult : IResult
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="BatchResult{TResult}"/> type.
		/// </summary>
		public BatchResult()
		{
			this.Results = new List<TResult>();
		}

		/// <summary>
		///		Gets the results.
		/// </summary>
		public IList<TResult> Results { get; }

		/// <inheritdoc />
		public bool IsFailed => this.Results.Any(x => x.IsFailed);

		/// <inheritdoc />
		public bool IsSuccessful => !this.IsFailed;

		/// <inheritdoc />
		public IList<IError> Errors => this.Results.SelectMany(x => x.Errors).ToList();

		/// <inheritdoc />
		public IList<ISuccess> Successes => this.Results.SelectMany(x => x.Successes).ToList();

		/// <summary>
		///		Adds a result to the batched result.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public BatchResult<TResult> WithResult(TResult result)
		{
			this.Results.Add(result);
			return this;
		}

		/// <summary>
		///		Adds multiple results to the batched result.
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		public BatchResult<TResult> WithResults(IEnumerable<TResult> results)
		{
			foreach (TResult result in results ?? Enumerable.Empty<TResult>())
			{
				this.Results.Add(result);
			}

			return this;
		}
	}
}