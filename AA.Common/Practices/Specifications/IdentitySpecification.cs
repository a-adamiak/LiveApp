using System;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of specyfication which pass all
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class IdentitySpecification<TType> : Specification<TType>
	{
		public override Expression<Func<TType, bool>> ToExpression()
		{
			return x => true;
		}
	}
}