using System;
using AAS.Common.Practices.Option.Core;

namespace AAS.Common.Practices.Option.Implementation
{
	internal class ActionResolved<T> : IActionable<T>, IFilteredActionable<T>, IFilteredNoneActionable<T>
	{
		public ActionResolved(Action action)
		{
			Action = action;
		}

		private Action Action { get; }

		public IFilteredActionable<T> When(Func<T, bool> predicate)
		{
			return this;
		}

		public IFilteredActionable<T> WhenSome()
		{
			return this;
		}

		public IFilteredNoneActionable<T> WhenNone()
		{
			return this;
		}

		public void Execute()
		{
			Action();
		}

		public IActionable<T> Do(Action<T> action)
		{
			return this;
		}

		public IActionable<T> Do(Action action)
		{
			return this;
		}
	}
}