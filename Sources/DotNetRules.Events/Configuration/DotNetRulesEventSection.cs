namespace DotNetRules.Events.Configuration
{
    using System.Configuration;

    public class DotNetRulesEventSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultContextName", DefaultValue = "root")]
        public string DefaultContextName
        {
            get
            {
                return this["defaultContextName"] as string;
            }
            set
            {
                this["defaultContextName"] = value;
            }
        }

        public static DotNetRulesEventSection Get()
        {
            return ConfigurationManager.GetSection("dotNetRules/events") as DotNetRulesEventSection
                   ?? new DotNetRulesEventSection();
        }
    }
}
