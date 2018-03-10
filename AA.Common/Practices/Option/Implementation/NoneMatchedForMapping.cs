using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class NoneMatchedForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>
	{
		public IMapped<T, TResult> MapTo(Func<TResult> mapping)
		{
			return new MappingResolved<T, TResult>(mapping());
		}
	}
}