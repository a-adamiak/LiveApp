using System;

namespace AAS.Common.Practices.Option.Core
{
	/// <typeparam name="TContent"></typeparam>
	public interface IFiltered<TContent> : IFilteredActionable<TContent>
	{
		IMapped<TContent, TResult> MapTo<TResult>(Func<TContent, TResult> mapping);
	}
}