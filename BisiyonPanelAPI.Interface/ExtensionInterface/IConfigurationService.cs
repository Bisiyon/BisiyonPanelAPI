using BisiyonPanelAPI.Common;
using Microsoft.Extensions.Configuration;

namespace BisiyonPanelAPI.Interface
{
    public interface IConfigurationService
    {
        IConfiguration Configuration { get; }

        T Get<T>(Enum_ConfigSetting key, T defaultValue);
        string GetFromSection(Enum_ConfigSection section, Enum_ConfigSetting key, string defaultValue = "");
    }
}