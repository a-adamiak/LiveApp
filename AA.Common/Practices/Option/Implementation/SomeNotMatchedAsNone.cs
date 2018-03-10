using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeNotMatchedAsNone<T> : IFilteredNone<T>
	{
		public SomeNotMatchedAsNone(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IActionable<T> Do(Action action)
		{
			return new ActionOnSomeNotResolved<T>(Value);
		}

		public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping)
		{
			return new MappingOnSomeNotResolved<T, TResult>(Value);
		}
	}
}