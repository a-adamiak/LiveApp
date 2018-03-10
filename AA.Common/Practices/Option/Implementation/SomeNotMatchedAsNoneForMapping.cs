using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeNotMatchedAsNoneForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>
	{
		public SomeNotMatchedAsNoneForMapping(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IMapped<T, TResult> MapTo(Func<TResult> mapping)
		{
			return new MappingOnSomeNotResolved<T, TResult>(Value);
		}
	}
}