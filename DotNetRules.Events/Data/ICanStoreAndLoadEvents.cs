namespace DotNetRules.Events.Data
{
    using System.Collections.Generic;

    public interface ICanStoreAndLoadEvents
    {
        void AddToStore<T>(T eventItem) where T : BaseEvent;

        IEnumerable<BaseEvent> GetAllEvents();

        IEnumerable<TEvents> GetSpecificEventsFromStore<TEvents>() where TEvents : BaseEvent;

        IEnumerable<TEvents> GetEventsFromStoreByBoundedContext<TEvents>() where TEvents : BaseEvent;
    }
}