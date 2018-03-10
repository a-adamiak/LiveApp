using System;

namespace AAS.Common.Base.Object
{
	public class Event
	{
		public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
	}
}