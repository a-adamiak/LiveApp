namespace AAS.Common.Base.Object
{
	public interface IAggregate<out TIdentity>
		where TIdentity : struct
	{
		TIdentity Id { get; }
	}
}