using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class NoneMatched<T> : IFilteredNone<T>, IFilteredNoneActionable<T>
	{
		public IActionable<T> Do(Action action)
		{
			return new ActionResolved<T>(action);
		}

		public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping)
		{
			return new MappingResolved<T, TResult>(mapping());
		}
	}
}