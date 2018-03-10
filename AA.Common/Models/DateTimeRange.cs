using System;
using AAS.Common.Enums;

namespace AAS.Common.Models
{

	public class DateTimeRange
	{

		public DateTime? From { get; private set; }
		public DateTime? To { get; private set; }
		public DateTimeRangeType RangeType { get; private set; }

		private DateTimeRange() { }

		public static DateTimeRange Range(DateTime from, DateTime to)
		{
			return new DateTimeRange
			{
				From = from,
				To = to,
				RangeType = DateTimeRangeType.Between
			};
		}

		public static DateTimeRange DateFrom(DateTime from)
		{
			return new DateTimeRange
			{
				From = from,
				RangeType = DateTimeRangeType.From
			};
		}

		public static DateTimeRange DateTo(DateTime to)
		{
			return new DateTimeRange
			{
				To = to,
				RangeType = DateTimeRangeType.From
			};
		}

		public override string ToString()
		{
			switch (RangeType)
			{
				case DateTimeRangeType.Between:
					return $"{From} - {To}";
				case DateTimeRangeType.From:
					return $"{From} - ...";
				case DateTimeRangeType.To:
					return $"{To} - ...";
				default:
					throw new Exception(
						$"Cannot display datetime range. Unhandled datetime range type {RangeType}");
			}
		}
	}
}