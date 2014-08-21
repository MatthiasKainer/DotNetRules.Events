namespace DotNetRules.Events.Entities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class EntityIdAttribute : Attribute
    {
        public static PropertyInfo GetEntityId<TFor>()
        {
            var props = typeof(TFor).GetProperties();
            PropertyInfo idFieldInfo = null;
            foreach (var prop in props)
            {
                if (prop.Name.ToLower() == "id") idFieldInfo = prop;

                var attrs = prop.GetCustomAttributes<EntityIdAttribute>(true);
                if (attrs.Any())
                {
                    return prop;
                }
            }

            return idFieldInfo;
        }
    }
}