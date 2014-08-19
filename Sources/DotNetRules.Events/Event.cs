namespace DotNetRules.Events
{
    using System;

    using DotNetRules.Events.Configuration;

    using Newtonsoft.Json;

    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
            this.Created = DateTime.Now;
            this.ContextName = DotNetRulesEventSection.Get().DefaultContextName;
        }

        public Guid Id { get; set; }

        public string ContextName { get; set; }

        public DateTime Created { get; set; }

        public string Author { get; set; }

        public string EntityContextType { get; set; }

        public string EventType { get; set; }

        public string EventBody { get; set; }

        public void Set<TEvent>(TEvent body)
        {
            var baseType = typeof(TEvent).BaseType;
            if (baseType != null)
            {
                this.EntityContextType = baseType.AssemblyQualifiedName;
            }

            this.EventType = typeof(TEvent).AssemblyQualifiedName;
            this.EventBody = JsonConvert.SerializeObject(body);
        }

        public TEvent Get<TEvent>()
        {
            return JsonConvert.DeserializeObject<TEvent>(this.EventBody);
        }

        public BaseEvent Get()
        {
            return (BaseEvent)JsonConvert.DeserializeObject(this.EventBody, Type.GetType(this.EventType));
        }
    }
}
