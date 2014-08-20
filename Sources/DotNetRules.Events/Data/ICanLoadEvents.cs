namespace DotNetRules.Events.Data
{
    using System.Collections.Generic;

    public interface ICanLoadEvents
    {
        IEnumerable<BaseEvent> GetAllEvents(string forApplication);

        IEnumerable<TEvents> GetSpecificEventsFromStore<TEvents>(string forApplication) where TEvents : BaseEvent;

        IEnumerable<TEvents> GetEventsFromStoreByEntity<TEvents>(string forApplication) where TEvents : BaseEvent;
    }
}