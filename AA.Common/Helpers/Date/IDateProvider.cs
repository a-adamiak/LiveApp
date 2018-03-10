using System;

namespace AAS.Common.Helpers.Date
{
	public interface IDateProvider
	{
		DateTimeOffset FirstDateOfWeek(int year, int weekOfYear);
		int GetIsoYearNumber(DateTimeOffset time);
		(DateTimeOffset from, DateTimeOffset to) GetMonthRange(int year, int month);
		int GetWeekNumber(DateTimeOffset time);
		(DateTimeOffset from, DateTimeOffset to) GetWeekRange(int year, int weekOfYear);
		int WeeksInYear(int year);
	}
}