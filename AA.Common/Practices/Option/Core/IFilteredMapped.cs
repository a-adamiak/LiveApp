using System;

namespace AAS.Common.Practices.Option.Core
{
	/// <summary>
	/// </summary>
	/// <typeparam name="TContent"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public interface IFilteredMapped<TContent, TResult>
	{
		IMapped<TContent, TResult> MapTo(Func<TContent, TResult> mapping);
	}
}