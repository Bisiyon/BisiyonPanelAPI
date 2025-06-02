using System.ComponentModel;
using System.Reflection;

namespace BisiyonPanelAPI.Service
{
    public static class EnumExtensions
    {
        public static string GetEnumName(this Enum enumValue)
        {
            return Enum.GetName(enumValue.GetType(), enumValue) ?? "";
        }

        public static string GetDescription(this Enum enumValue, bool isResource = false)
        {
            try
            {
                if (enumValue is null)
                {
                    return "";
                }
                FieldInfo? fi = enumValue.GetType().GetField(enumValue.ToString());
                if (fi is null)
                {
                    return "";
                }
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                return attributes != null && attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}