using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class SomeMatchedForMapping<T, TResult> : IFilteredMapped<T, TResult>
	{
		private readonly T Value;

		public SomeMatchedForMapping(T value)
		{
			Value = value;
		}

		public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
		{
			return new MappingResolved<T, TResult>(mapping(Value));
		}
	}
}