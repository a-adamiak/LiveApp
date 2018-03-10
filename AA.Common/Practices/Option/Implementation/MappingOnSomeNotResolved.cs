using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class MappingOnSomeNotResolved<T, TResult> : IMapped<T, TResult>
	{
		public MappingOnSomeNotResolved(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IFilteredMapped<T, TResult> When(Func<T, bool> predicate)
		{
			return predicate(Value)
				? (IFilteredMapped<T, TResult>) new SomeMatchedForMapping<T, TResult>(Value)
				: new SomeNotMatchedForMapping<T, TResult>(Value);
		}

		public IFilteredMapped<T, TResult> WhenSome()
		{
			return new SomeMatchedForMapping<T, TResult>(Value);
		}

		public IFilteredNoneMapped<T, TResult> WhenNone()
		{
			return new SomeNotMatchedAsNoneForMapping<T, TResult>(Value);
		}

		public TResult Map()
		{
			throw new InvalidOperationException();
		}
	}
}