using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using AAS.Common.Enums;
using AAS.Common.Extensions;
using ExtraConstraints;

namespace AAS.Common.Helpers.Enums
{
	public static class EnumConverter
	{
		public static string ToString<[EnumConstraint] TEnum>(TEnum enumValue, DisplayType displayType)
		{
			switch (displayType)
			{
				case DisplayType.Value:
					return enumValue.ToString();
				case DisplayType.DisplayName:
					return enumValue.GetEnumAttribute<TEnum,DisplayAttribute>().Name;
				case DisplayType.Description:
					return enumValue.GetEnumAttribute<TEnum, DescriptionAttribute>().Description;
				case DisplayType.ResourceDisplayName:

					DisplayAttribute displayAttribute = enumValue.GetEnumAttribute<TEnum, DisplayAttribute>();
					ResourceManager resManager = new ResourceManager(displayAttribute.ResourceType);
					return resManager.GetString(displayAttribute.Name);
				default:
					return string.Empty;
			}
		}
	}
}