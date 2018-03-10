using System;

namespace AAS.Common.Helpers.Date
{
	public interface IDateProvider
	{
		DateTime FirstDateOfWeek(int year, int weekOfYear);
		int GetIsoYearNumber(DateTime time);
		(DateTime from, DateTime to) GetMonthRange(int year, int month);
		int GetWeekNumber(DateTime time);
		(DateTime from, DateTime to) GetWeekRange(int year, int weekOfYear);
		int WeeksInYear(int year);
	}
}