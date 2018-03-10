using AAS.Common.Base.Object;

namespace AAS.Common.Base.Process
{
    public interface IEventStore
    {
		void Save<TEvent>(TEvent theEvent) where TEvent : Event;
    }
}
