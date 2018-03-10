using System.Collections.Generic;
using AAS.Common.Practices.Option;

namespace AAS.Common.Extensions
{
	public static class DictionaryExtensions
	{
		public static Option<TResult> Get<TKey, TResult>(this IDictionary<TKey, TResult> dictionary, TKey key)
		{
			dictionary.TryGetValue(key, out TResult result);
			return Option<TResult>.Some(result);
		}
	}
}