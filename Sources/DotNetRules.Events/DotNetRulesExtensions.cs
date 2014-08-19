namespace DotNetRules.Events
{
    public static class DotNetRulesExtensions
    {
        public static void Publish(this BaseEvent @event)
        {
            @event.ApplyPolicies();
        }
    }
}
