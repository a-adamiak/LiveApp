using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeNotMatchedForMapping<T, TResult> : IFilteredMapped<T, TResult>
	{
		private readonly T Value;

		public SomeNotMatchedForMapping(T value)
		{
			Value = value;
		}

		public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
		{
			return new MappingOnSomeNotResolved<T, TResult>(Value);
		}
	}
}