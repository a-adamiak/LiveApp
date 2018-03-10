using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class ActionOnNoneNotResolved<T> : IActionable<T>
	{
		public IFilteredActionable<T> When(Func<T, bool> predicate)
		{
			return new NoneNotMatchedAsSome<T>();
		}

		public IFilteredActionable<T> WhenSome()
		{
			return new NoneNotMatchedAsSome<T>();
		}

		public IFilteredNoneActionable<T> WhenNone()
		{
			return new NoneMatched<T>();
		}

		public void Execute()
		{
		}
	}
}