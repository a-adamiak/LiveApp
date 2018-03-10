namespace AAS.Common.Practices.Chain
{
	public abstract class ChainElement<TContent> : IChainElement<TContent>
		where TContent : class, IChainElement<TContent>
	{
		protected readonly TContent Next;

		protected ChainElement(TContent next)
		{
			this.Next = next;
		}

		protected ChainElement()
		{
			Next = Empty;
		}

		/// <summary>
		///     This elements should do nothing.
		///     Allows to avoid using null guard
		/// </summary>
		public abstract TContent Empty { get; }

		/// <summary>
		///     Returns element with specific type. Eventually it will be an empty element
		/// </summary>
		/// <typeparam name="TTarget"></typeparam>
		/// <returns></returns>
		public virtual TTarget As<TTarget>() where TTarget : class, TContent
		{
			TTarget thisAsTarget = this as TTarget;
			return thisAsTarget ?? Next.As<TTarget>();
		}
	}
}