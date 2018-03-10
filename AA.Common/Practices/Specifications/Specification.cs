using System;
using System.Linq.Expressions;

namespace AAS.Common.Practices.Specifications
{
	/// <summary>
	///     Core class for specification pattern. Allows encapsulate an in memory query and a database query.
	/// </summary>
	/// <typeparam name="TType">Type for queries</typeparam>
	public abstract class Specification<TType>
	{
		/// <summary>
		///     Query for all entitities
		/// </summary>
		public static readonly Specification<TType> All = new IdentitySpecification<TType>();

		/// <summary>
		///     Compile query to expression. Can be used in database query.
		/// </summary>
		/// <returns>Type for queries</returns>
		public abstract Expression<Func<TType, bool>> ToExpression();

		/// <summary>
		///     Executes query for given entity
		/// </summary>
		/// <param name="entity">Type for queries</param>
		/// <returns>Result of predicate</returns>
		public bool IsSatisfiedBy(TType entity)
		{
			Func<TType, bool> predicate = ToExpression().Compile();
			return predicate(entity);
		}

		/// <summary>
		///     Combines with second expression using and operator
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public Specification<TType> And(Specification<TType> specification)
		{
			return new AndSpecification<TType>(this, specification);
		}

		/// <summary>
		///     Combines with second expression using and not operator
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public Specification<TType> AndNot(Specification<TType> specification)
		{
			return new AndNotSpecification<TType>(this, specification);
		}

		/// <summary>
		///     Combines with second expression using or operator
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public Specification<TType> Or(Specification<TType> specification)
		{
			return new OrSpecification<TType>(this, specification);
		}

		/// <summary>
		///     Combines with second expression using or not operator
		/// </summary>
		/// <param name="specification"></param>
		/// <returns></returns>
		public Specification<TType> OrNot(Specification<TType> specification)
		{
			return new OrNotSpecification<TType>(this, specification);
		}

		/// <summary>
		///     Negation of current expression
		/// </summary>
		/// <returns></returns>
		public Specification<TType> Not()
		{
			return new NotSpecification<TType>(this);
		}
	}
}