using System;
using System.Linq;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of two specifications connected with and operator
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class AndSpecification<TType> : Specification<TType>
	{
		private readonly Specification<TType> left;
		private readonly Specification<TType> right;

		public AndSpecification(Specification<TType> left, Specification<TType> right)
		{
			this.left = left;
			this.right = right;
		}


		public override Expression<Func<TType, bool>> ToExpression()
		{
			Expression<Func<TType, bool>> leftExpression = left.ToExpression();
			Expression<Func<TType, bool>> rightExpression = right.ToExpression();

			BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

			return Expression.Lambda<Func<TType, bool>>(andExpression, leftExpression.Parameters.Single());
		}
	}
}