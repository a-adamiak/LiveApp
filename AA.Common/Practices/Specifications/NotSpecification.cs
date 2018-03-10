using System;
using System.Linq;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of specification negation
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class NotSpecification<TType> : Specification<TType>
	{
		private readonly Specification<TType> spec;

		public NotSpecification(Specification<TType> spec)
		{
			this.spec = spec;
		}


		public override Expression<Func<TType, bool>> ToExpression()
		{
			Expression<Func<TType, bool>> specExpression = spec.ToExpression();

			UnaryExpression notExpression = Expression.Not(specExpression.Body);

			return Expression.Lambda<Func<TType, bool>>(notExpression, specExpression.Parameters.Single());
		}
	}
}