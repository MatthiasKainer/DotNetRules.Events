namespace DotNetRules.Events
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using DotNetRules.Events.Entities;
    using DotNetRules.Events.Helpers;
    using DotNetRules.Events.Properties;

    public static class EventExtensions
    {
        public static IEnumerable<TTarget> For<TTarget, TEvent>(this IEnumerable<TEvent> events)
            where TEvent : BaseEvent
        {
            var targetType = typeof(TTarget);
            var resultList = new Dictionary<string, TTarget>();

            var constructorInfo = Errors.ThrowIfNull(() => targetType.GetConstructor(new[] { typeof(string), typeof(string) }),
                new Exception(string.Format(Resources.EventTarget_no_constructor_found, targetType)));

            var identifierProperty = Errors.ThrowIfNull(EntityIdAttribute.GetEntityId<TTarget>, 
                new MissingPrimaryKeyException(string.Format(Resources.EventTarget_No_Id, targetType)));

            var applyAllMethod = Errors.ThrowIfNull(ApplyAllEventsAttribute.GetApplyAllEventsMethod<TTarget>,
                new MissingMethodException(string.Format(Resources.EventTarget_No_ApplyAll, targetType)));

            foreach (var @event in events)
            {
                var currentTarget = (TTarget)constructorInfo.Invoke(null);
                var currentId = identifierProperty.GetValue(currentTarget) ?? string.Empty;
                if (resultList.ContainsKey(currentId.ToString())) currentTarget = resultList[currentId.ToString()];
                applyAllMethod.Invoke(currentTarget, new object[] { @event });
            }

            return resultList.Values;
        }
    }
}
