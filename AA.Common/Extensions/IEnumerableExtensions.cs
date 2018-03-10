using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAS.Common.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IOrderedEnumerable<TSource> OrderRandom<TSource>(this IEnumerable<TSource> source)
		{
			return source.OrderBy(element => Guid.NewGuid());
		}

		public static IOrderedEnumerable<TSource> ThenRandom<TSource>(this IOrderedEnumerable<TSource> source)
		{
			return source.ThenBy(element => Guid.NewGuid());
		}

		public static IEnumerable<Task> ExecuteTasks<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> task)
		{
			return source.Select(element => task(element));
		}

		public static IEnumerable<Task> ExecuteTasks<TSource, TResult>(this IEnumerable<TSource> source,
			Func<TSource, Task<TResult>> task)
		{
			return source.Select(element => task(element));
		}

		public static Task ExecuteAndSynchronizeTasks<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> task)
		{
			return Task.WhenAll(ExecuteTasks(source, task));
		}

		public static Task ExecuteAndSynchronizeTasks<TSource, TResult>(this IEnumerable<TSource> source,
			Func<TSource, Task<TResult>> task)
		{
			return Task.WhenAll(ExecuteTasks(source, task));
		}
	}
}