using System;

namespace AAS.Common.Practices.Option.Core
{
	public interface IActionable<TContent>
	{
		/// <summary>
		///     Allows execute some logic when the specified condition is met
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IFilteredActionable<TContent> When(Func<TContent, bool> predicate);

		/// <summary>
		///     Allows execute some logic when object has specified value
		/// </summary>
		/// <returns></returns>
		IFilteredActionable<TContent> WhenSome();

		/// <summary>
		///     Allows execute some logic when object has not specified value
		/// </summary>
		/// <returns></returns>
		IFilteredNoneActionable<TContent> WhenNone();

		/// <summary>
		///     Execute all stored logic
		/// </summary>
		void Execute();
	}
}