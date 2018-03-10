using System;

namespace AAS.Common.Practices.Option.Core
{
	/// <summary>
	///     Allows to add logic executed when stored condition is met
	/// </summary>
	/// <typeparam name="TContent"></typeparam>
	public interface IFilteredActionable<TContent>
	{
		/// <summary>
		///     Add logic executed when stored condition is met
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		IActionable<TContent> Do(Action<TContent> action);
	}
}