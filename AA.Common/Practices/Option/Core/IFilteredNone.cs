using System;

namespace AAS.Common.Practices.Option.Core
{
	public interface IFilteredNone<TContent>
	{
		IActionable<TContent> Do(Action action);
		IMapped<TContent, TResult> MapTo<TResult>(Func<TResult> mapping);
	}
}