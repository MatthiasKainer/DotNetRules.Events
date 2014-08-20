namespace DotNetRules.Events.Data
{
    public interface ICanStoreEvents
    {
        void AddToStore<T>(T eventItem) where T : BaseEvent;
    }
}