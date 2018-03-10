using System;
using System.Linq;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Encapsulation of two specifications connected with or operator
	/// </summary>
	/// <typeparam name="TType"></typeparam>
	internal sealed class OrSpecification<TType> : Specification<TType>
	{
		private readonly Specification<TType> left;
		private readonly Specification<TType> right;

		public OrSpecification(Specification<TType> left, Specification<TType> right)
		{
			this.left = left;
			this.right = right;
		}


		public override Expression<Func<TType, bool>> ToExpression()
		{
			Expression<Func<TType, bool>> leftExpression = left.ToExpression();
			Expression<Func<TType, bool>> rightExpression = right.ToExpression();

			BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

			return Expression.Lambda<Func<TType, bool>>(orExpression, leftExpression.Parameters.Single());
		}
	}
}