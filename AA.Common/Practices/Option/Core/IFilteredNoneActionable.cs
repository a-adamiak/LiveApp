using System;

namespace AAS.Common.Practices.Option.Core
{
	/// <summary>
	///     Allows to add logic executed when object has no specified value
	/// </summary>
	/// <typeparam name="TContent"></typeparam>
	public interface IFilteredNoneActionable<TContent>
	{
		/// <summary>
		///     Add logic executed when object has no specified value
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		IActionable<TContent> Do(Action action);
	}
}