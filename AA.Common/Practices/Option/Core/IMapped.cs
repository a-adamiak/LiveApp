using System;

namespace AAS.Common.Practices.Option.Core
{
	/// <summary>
	///     Allows to map value which will be returned
	/// </summary>
	/// <typeparam name="TContent"></typeparam>
	/// <typeparam name="TResult"></typeparam>
	public interface IMapped<TContent, TResult>
	{
		/// <summary>
		///     Add condition which
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IFilteredMapped<TContent, TResult> When(Func<TContent, bool> predicate);

		/// <summary>
		///     Add mapping logic when object has specified Value
		/// </summary>
		/// <returns></returns>
		IFilteredMapped<TContent, TResult> WhenSome();

		/// <summary>
		///     Add mapping logic when object has no specified Value
		/// </summary>
		/// <returns></returns>
		IFilteredNoneMapped<TContent, TResult> WhenNone();

		/// <summary>
		///     Returns value which deals with given mapping logic
		/// </summary>
		/// <returns></returns>
		TResult Map();
	}
}