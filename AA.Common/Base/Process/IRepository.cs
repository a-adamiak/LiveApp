using System.Collections.Generic;
using AAS.Common.Base.Object;
using AAS.Common.Practices.Option;

namespace AAS.Common.Base.Process
{
	public interface IRepository<TAggregate, in TIdentity>
		where TAggregate : class, IAggregate<TIdentity>
		where TIdentity : struct
	{
		IEnumerable<TAggregate> All { get; }
		Option<TAggregate> Find(TIdentity identity);
		bool Save(TAggregate entity);
		bool Delete(TAggregate entity);
	}
}