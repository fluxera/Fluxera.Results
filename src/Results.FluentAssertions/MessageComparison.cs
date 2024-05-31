namespace Fluxera.Results.FluentAssertions
{
	using System;
	using JetBrains.Annotations;

	/// <summary>
    ///		Contains the default message comparison functions.
    /// </summary>
    [PublicAPI]
    public static class MessageComparison
    {
        /// <summary>
        ///		Compare using the equals' operator.
        /// </summary>
        public static Func<string, string, bool> Equal = (actual, expected) => actual == expected;

        /// <summary>
        ///		Compare using the contains method.
        /// </summary>
        public static Func<string, string, bool> Contains = (actual, expected) => actual.Contains(expected);
    }
}