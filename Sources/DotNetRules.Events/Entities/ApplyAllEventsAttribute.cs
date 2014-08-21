namespace DotNetRules.Events.Entities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ApplyAllEventsAttribute : Attribute
    {
        public static MethodInfo GetApplyAllEventsMethod<TFor>()
        {
            var methodInfos = typeof(TFor).GetMethods();
            MethodInfo applyMethod = null;
            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.Name.ToLower() == "applyall") applyMethod = methodInfo;

                var attrs = methodInfo.GetCustomAttributes<ApplyAllEventsAttribute>(true);
                if (attrs.Any())
                {
                    return methodInfo;
                }
            }

            return applyMethod;
        }
    }
}