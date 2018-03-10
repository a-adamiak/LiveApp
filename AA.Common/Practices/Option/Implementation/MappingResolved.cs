using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class MappingResolved<T, TResult> : IMapped<T, TResult>, IFilteredMapped<T, TResult>,
		IFilteredNoneMapped<T, TResult>
	{
		public MappingResolved(TResult result)
		{
			Result = result;
		}

		private TResult Result { get; }

		public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
		{
			return this;
		}

		public IMapped<T, TResult> MapTo(Func<TResult> mapping)
		{
			return this;
		}

		public IFilteredMapped<T, TResult> When(Func<T, bool> predicate)
		{
			return this;
		}

		public IFilteredMapped<T, TResult> WhenSome()
		{
			return this;
		}

		public IFilteredNoneMapped<T, TResult> WhenNone()
		{
			return this;
		}

		public TResult Map()
		{
			return Result;
		}
	}
}