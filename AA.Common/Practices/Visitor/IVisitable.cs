using System;

namespace AAS.Common.Practices.Visitor
{
	public interface IVisitable<in TVisitor, out TRequirements>
		where TVisitor : IVisitor<TRequirements>
		where TRequirements : IVisitorRequirements
	{
		TRequirements AcceptWithResult(Func<TVisitor> visitorFactory);
		void Accept(Func<TVisitor> visitorFactory);
	}
}