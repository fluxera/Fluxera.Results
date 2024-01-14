namespace MadEyeMatt.Results.FluentAssertions
{
	using System.Collections.Generic;
	using global::FluentAssertions;
	using JetBrains.Annotations;

	/// <inheritdoc />
	[PublicAPI]
	public sealed class AndWhichThatConstraint<TParentConstraint, TMatchedElement, TThatConstraint> : AndWhichConstraint<TParentConstraint, TMatchedElement>
	{
		/// <inheritdoc />
		public AndWhichThatConstraint(TParentConstraint parentConstraint, TMatchedElement matchedConstraint, TThatConstraint thatConstraint) 
			: base(parentConstraint, matchedConstraint)
		{
			this.That = thatConstraint;
		}

		/// <inheritdoc />
		public AndWhichThatConstraint(TParentConstraint parentConstraint, IEnumerable<TMatchedElement> matchedConstraint, TThatConstraint thatConstraint) 
			: base(parentConstraint, matchedConstraint)
		{
			this.That = thatConstraint;
		}

		/// <summary>
		///		Gets the That constraint.
		/// </summary>
		public TThatConstraint That { get; }
	}
}