namespace AAS.Common.Practices.Stratety
{
	public interface IStrategyResolver
	{
		TType Resolve<TType>(string namedKey);

		void Register<TType>(string namedKey, TType obj);
	}
}