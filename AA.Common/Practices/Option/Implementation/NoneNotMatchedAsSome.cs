using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class NoneNotMatchedAsSome<T> : IFiltered<T>
	{
		public IActionable<T> Do(Action<T> action)
		{
			return new ActionOnNoneNotResolved<T>();
		}

		public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
		{
			return new MappingOnNoneNotResolved<T, TResult>();
		}
	}
}