using System;
using AAS.Common.Enums;

namespace AAS.Common.Models
{

	public class DateTimeRange
	{

		public DateTimeOffset? From { get; private set; }
		public DateTimeOffset? To { get; private set; }
		public DateTimeRangeType RangeType { get; private set; }

		private DateTimeRange() { }

		public static DateTimeRange Range(DateTimeOffset from, DateTimeOffset to)
		{
			return new DateTimeRange
			{
				From = from,
				To = to,
				RangeType = DateTimeRangeType.Between
			};
		}

		public static DateTimeRange DateFrom(DateTimeOffset from)
		{
			return new DateTimeRange
			{
				From = from,
				RangeType = DateTimeRangeType.From
			};
		}

		public static DateTimeRange DateTo(DateTimeOffset to)
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