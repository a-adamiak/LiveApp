namespace AAS.Common.Practices.Visitor
{
	public interface IVisitor<in TRequirements> where TRequirements : IVisitorRequirements
	{
		void Visit(TRequirements parameters);
	}
}