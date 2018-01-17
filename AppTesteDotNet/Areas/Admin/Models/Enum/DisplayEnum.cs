using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace AppTesteDotNet.Areas.Admin.Models.Enum
{
    public class DisplayEnum
    {
        public static string GetDisplayName(System.Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}