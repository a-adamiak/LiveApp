using System;
using System.Linq;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of two specifications connected with and not operator
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class AndNotSpecification<TType> : Specification<TType>
	{
		private readonly Specification<TType> left;
		private readonly Specification<TType> right;

		public AndNotSpecification(Specification<TType> left, Specification<TType> right)
		{
			this.left = left;
			this.right = right;
		}


		public override Expression<Func<TType, bool>> ToExpression()
		{
			Expression<Func<TType, bool>> leftExpression = left.ToExpression();
			Expression<Func<TType, bool>> rightExpression = right.ToExpression();

			UnaryExpression notRightExpression = Expression.Not(rightExpression.Body);
			BinaryExpression andNotExpression = Expression.And(leftExpression.Body, notRightExpression);

			return Expression.Lambda<Func<TType, bool>>(andNotExpression, leftExpression.Parameters.Single());
		}
	}
}