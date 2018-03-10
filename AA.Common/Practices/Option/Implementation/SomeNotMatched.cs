using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeNotMatched<T> : IFiltered<T>, IFilteredNoneActionable<T>
	{
		public SomeNotMatched(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IActionable<T> Do(Action<T> action)
		{
			return new ActionOnSomeNotResolved<T>(Value);
		}

		public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
		{
			return new MappingOnSomeNotResolved<T, TResult>(Value);
		}

		public IActionable<T> Do(Action action)
		{
			return new ActionOnSomeNotResolved<T>(Value);
		}
	}
}