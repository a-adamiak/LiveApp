using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeMatched<T> : IFiltered<T>
	{
		public SomeMatched(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IActionable<T> Do(Action<T> action)
		{
			return new ActionResolved<T>(() => action(Value));
		}

		public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
		{
			return new MappingResolved<T, TResult>(mapping(Value));
		}
	}
}