using System;

namespace AAS.Common.Practices.Option.Core
{
	public interface IFilteredNoneMapped<TContent, TResult>
	{
		IMapped<TContent, TResult> MapTo(Func<TResult> mapping);
	}
}