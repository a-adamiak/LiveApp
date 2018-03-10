using System;
using System.Globalization;

namespace AAS.Common.Helpers.Date
{
	public class IsoDateProvider : IDateProvider
	{
		public DateTimeOffset FirstDateOfWeek(int year, int weekOfYear)
		{
			DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
			CultureInfo ci = CultureInfo.InvariantCulture;
			DateTime jan1 = new DateTime(year, 1, 1);
			int daysOffset = (int) firstDayOfWeek - (int) jan1.DayOfWeek;
			DateTime firstWeekDay = jan1.AddDays(daysOffset);
			int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, firstDayOfWeek);
			if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3) weekOfYear -= 1;
			return firstWeekDay.AddDays(weekOfYear * 7);
		}

		public (DateTimeOffset from, DateTimeOffset to) GetWeekRange(int year, int weekOfYear)
		{
			DateTimeOffset firstDay = FirstDateOfWeek(year, weekOfYear);
			DateTimeOffset lastDay = firstDay.AddDays(6);
			return (firstDay, lastDay);
		}

		public (DateTimeOffset from, DateTimeOffset to) GetMonthRange(int year, int month)
		{
			DateTime firstDay = new DateTime(year, month, 1);
			DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);
			return (firstDay, lastDay);
		}

		public int WeeksInYear(int year)
		{
			DateTime time = new DateTime(year, 12, 31);
			DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
			if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) time = time.AddDays(-3);
			// Return the week of our adjusted day
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek,
				DayOfWeek.Monday);
		}

		public int GetWeekNumber(DateTimeOffset time)
		{
			DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time.DateTime);
			if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) time = time.AddDays(3);

			// Return the week of our adjusted day
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time.DateTime, CalendarWeekRule.FirstFourDayWeek,
				DayOfWeek.Monday);
		}

		public int GetIsoYearNumber(DateTimeOffset time)
		{
			CultureInfo cul = CultureInfo.CurrentCulture;
			int weekNum = cul.Calendar.GetWeekOfYear(
				time.DateTime,
				CalendarWeekRule.FirstFourDayWeek,
				DayOfWeek.Monday);
			int year = weekNum >= 52 && time.Month == 1 ? time.Year - 1 : time.Year;
			return year;
		}
	}
}