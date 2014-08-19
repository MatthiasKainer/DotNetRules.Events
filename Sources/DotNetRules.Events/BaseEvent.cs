namespace DotNetRules.Events
{
    public class BaseEvent
    {
        public string User { get; set; }

        public string ContextName { get; set; }

        public BaseEvent()
        {
        }

        public BaseEvent(string contextName, string user)
        {
            this.ContextName = contextName;
            User = user;
        }
    }
}
