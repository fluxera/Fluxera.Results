namespace MadEyeMatt.Results.FluentAssertions
{
	using global::FluentAssertions.Formatting;
	using System.Collections.Generic;
	using System.Linq;

	internal static class ResultFormatters
	{
		public static void Register()
		{
			Formatter.AddFormatter(new ErrorListValueFormatter());
			Formatter.AddFormatter(new SuccessListValueFormatter());
		}

		private class ErrorListValueFormatter : IValueFormatter
		{
			public bool CanHandle(object value)
			{
				return value is List<IError>;
			}

			public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
			{
				IEnumerable<IError> errors = (IEnumerable<IError>)value;
				formattedGraph.AddFragment("\"");
				formattedGraph.AddFragment(string.Join("; ", errors.Select(error => error.Message)));
				formattedGraph.AddFragment("\"");
			}
		}

		private class SuccessListValueFormatter : IValueFormatter
		{
			public bool CanHandle(object value)
			{
				return value is List<ISuccess>;
			}

			public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
			{
				IEnumerable<ISuccess> errors = (IEnumerable<ISuccess>)value;
				formattedGraph.AddFragment("\"");
				formattedGraph.AddFragment(string.Join("; ", errors.Select(error => error.Message)));
				formattedGraph.AddFragment("\"");
			}
		}
	}
}