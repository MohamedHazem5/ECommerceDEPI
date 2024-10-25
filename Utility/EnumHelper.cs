using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Utility
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<T>(this T enumValue)
            where T : Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }

        public static string GetEnumDisplayName<T>(this T enumValue)
        where T : Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].Name : enumValue.ToString();
        }
    }
}
