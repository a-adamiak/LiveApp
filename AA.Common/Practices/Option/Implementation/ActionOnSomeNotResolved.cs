using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class ActionOnSomeNotResolved<T> : IActionable<T>
	{
		public ActionOnSomeNotResolved(T value)
		{
			Value = value;
		}

		private T Value { get; }

		public IFilteredActionable<T> When(Func<T, bool> predicate)
		{
			return predicate(Value) ? (IFilteredActionable<T>) new SomeMatched<T>(Value) : new SomeNotMatched<T>(Value);
		}

		public IFilteredActionable<T> WhenSome()
		{
			return new SomeMatched<T>(Value);
		}

		public IFilteredNoneActionable<T> WhenNone()
		{
			return new SomeNotMatched<T>(Value);
		}

		public void Execute()
		{
		}
	}
}