using System;
using System.Collections.Generic;

namespace AAS.Common.Practices.Option.Extensions
{
	public static class EnumerableExtensions
	{
		public static void Do<TContent>(this IEnumerable<TContent> collection, Action<TContent> action)
		{
			foreach (TContent elem in collection)
				action(elem);
		}
	}
}