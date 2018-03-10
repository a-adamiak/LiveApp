using System;
using System.Collections.Generic;
using System.Threading;

namespace AAS.Common.Helpers
{
	public class Scheduler
	{
		private static Scheduler instance;
		private readonly List<Timer> timers = new List<Timer>();

		private Scheduler()
		{
		}

		public static Scheduler Instance => instance ?? (instance = new Scheduler());

		public void ScheduleTask(int hour, int min, double intervalInHour, Action task)
		{
			DateTime now = DateTime.Now;
			DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);
			if (now > firstRun) firstRun = firstRun.AddDays(1);

			TimeSpan timeToGo = firstRun - now;
			if (timeToGo <= TimeSpan.Zero) timeToGo = TimeSpan.Zero;

			Timer timer = new Timer(x => { task.Invoke(); }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

			timers.Add(timer);
		}

		public void ScheduleTask(DateTime startDate, double intervalInHour, Action task)
		{
			DateTime now = DateTime.Now;
			DateTime firstRun = startDate;
			if (now > firstRun) firstRun = firstRun.AddDays(1);

			TimeSpan timeToGo = firstRun - now;
			if (timeToGo <= TimeSpan.Zero) timeToGo = TimeSpan.Zero;

			Timer timer = new Timer(x => { task.Invoke(); }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

			timers.Add(timer);
		}
	}
}