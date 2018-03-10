using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class NoneNotMatchedForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>, IFilteredMapped<T, TResult>
	{
		public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
		{
			return new MappingOnNoneNotResolved<T, TResult>();
		}

		public IMapped<T, TResult> MapTo(Func<TResult> mapping)
		{
			return new MappingOnNoneNotResolved<T, TResult>();
		}
	}
}