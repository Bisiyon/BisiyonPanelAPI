using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using Microsoft.Extensions.Configuration;

namespace BisiyonPanelAPI.Service
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration Configuration { get; set; }
        public ConfigurationService(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public T Get<T>(Enum_ConfigSetting key, T defaultValue)
        {
            T? value = Configuration.GetValue<T>(key.GetEnumName());
            return value ?? defaultValue;
        }

        public string GetFromSection(Enum_ConfigSection section, Enum_ConfigSetting key, string defaultValue = "")
        {
            IConfigurationSection? configSection = Configuration.GetSection(section.GetEnumName());
            if (configSection is null) return defaultValue;
            string? value = configSection[key.GetEnumName()];
            return value ?? defaultValue;
        }
    }
}