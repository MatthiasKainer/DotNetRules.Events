namespace DotNetRules.Events.Data
{
    using System.Collections.Generic;

    public interface ICanLoadEventsForOwners
    {
        IEnumerable<BaseEvent> GetAllEvents(string forApplication);

        IEnumerable<TEvents> GetSpecificEventsFromStore<TEvents>(string forApplication, string owner) where TEvents : BaseEvent;

        IEnumerable<TEvents> GetEventsFromStoreByEntity<TEvents>(string forApplication, string owner) where TEvents : BaseEvent;
    }
}