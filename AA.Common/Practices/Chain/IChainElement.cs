namespace AAS.Common.Practices.Chain
{
	public interface IChainElement<in TContent> where TContent : IChainElement<TContent>
	{
		TTarget As<TTarget>() where TTarget : class, TContent;
	}
}