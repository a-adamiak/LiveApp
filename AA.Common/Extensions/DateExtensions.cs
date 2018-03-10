using System;
using System.Collections.Generic;

namespace AAS.Common.Extensions
{
	public static class DateExtensions
	{
		public static IEnumerable<DateTimeOffset> EachDay(this DateTimeOffset from, DateTimeOffset to)
		{
			DateTimeOffset day;
			for (day = from.Date; day.Date <= to.Date; day.AddDays(1)) yield return day;
		}

		public static IEnumerable<DateTime> EachDay(this DateTime from, DateTime to)
		{
			DateTime day;
			for (day = from.Date; day.Date <= to.Date; day.AddDays(1)) yield return day;
		}
	}
}