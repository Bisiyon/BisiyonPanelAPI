namespace BisiyonPanelAPI.Common
{
    public enum Enum_ConfigSetting
    {
        [ParentConfigSection(Enum_ConfigSection.JwtSettings)]
        JWTSecret,
        [ParentConfigSection(Enum_ConfigSection.JwtSettings)]
        JWTValidIssuer,
        [ParentConfigSection(Enum_ConfigSection.JwtSettings)]
        JWTValidAudience,
        [ParentConfigSection(Enum_ConfigSection.JwtSettings)]
        JWTExpiresIn,
        [ParentConfigSection(Enum_ConfigSection.JwtSettings)]
        JWTRefreshTokenExpiresIn
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ParentConfigSectionAttribute : Attribute
    {
        public ParentConfigSectionAttribute(Enum_ConfigSection section)
        {
            Section = section;
        }

        public Enum_ConfigSection Section { get; set; }
    }
}