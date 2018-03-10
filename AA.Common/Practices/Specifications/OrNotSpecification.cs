using System;
using System.Linq;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of two specifications connected with or not operator
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class OrNotSpecification<TType> : Specification<TType>
	{
		private readonly Specification<TType> left;
		private readonly Specification<TType> right;

		public OrNotSpecification(Specification<TType> left, Specification<TType> right)
		{
			this.left = left;
			this.right = right;
		}


		public override Expression<Func<TType, bool>> ToExpression()
		{
			Expression<Func<TType, bool>> leftExpression = left.ToExpression();
			Expression<Func<TType, bool>> rightExpression = right.ToExpression();

			UnaryExpression notRightExpression = Expression.Not(rightExpression.Body);
			BinaryExpression orNotExpression = Expression.OrElse(leftExpression.Body, notRightExpression);

			return Expression.Lambda<Func<TType, bool>>(orNotExpression, leftExpression.Parameters.Single());
		}
	}
}