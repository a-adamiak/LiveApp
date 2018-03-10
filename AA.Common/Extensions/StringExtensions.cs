using System;
using System.Globalization;
using System.Linq;
using System.Text;
using AAS.Common.Practices.Option;

namespace AAS.Common.Extensions
{
	public static class StringExtensions
	{
		public static Option<int> ToOptionalInt(this string value)
		{
			int.TryParse(value, out int result);
			return result;
		}

		public static Option<short> ToOptionalShort(this string value)
		{
			short.TryParse(value, out short result);
			return result;
		}

		public static Option<decimal> ToOptionalDecimal(this string value)
		{
			decimal.TryParse(value, out decimal result);
			return result;
		}

		public static Option<DateTime> ToOptionalDateTime(this string value)
		{
			DateTime.TryParse(value, out DateTime result);
			return result;
		}

		public static string ToUpperCase(this string input)
		{
			if (string.IsNullOrEmpty(input)) return input;

			string toLower = input.ToLowerInvariant();

			return toLower.First().ToString().ToUpper() + string.Join("", toLower.Skip(1));
		}

		public static string SubStringAfter(this string input, string after)
		{
			return input.Substring(input.IndexOf(after, StringComparison.Ordinal) + after.Length);
		}

		public static string RemoveDiacritics(this string text)
		{
			string normalizedString = text.Normalize(NormalizationForm.FormD);

			StringBuilder builder = new StringBuilder();

			foreach (char character in normalizedString)
			{
				UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
				if (category != UnicodeCategory.NonSpacingMark) builder.Append(character);
			}

			return builder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}