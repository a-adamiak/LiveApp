using System;
using System.Collections.Generic;
using System.Linq;
using AAS.Common.Enums;
using ExtraConstraints;

namespace AAS.Common.Helpers.Enums
{
	public static class EnumCollections
	{
		public static IEnumerable<TEnumType> Of<[EnumConstraint] TEnumType>()
		{
			Type enumType = typeof(TEnumType);

			return Enum.GetValues(enumType).Cast<TEnumType>();
		}

		public static IEnumerable<TEnumType> OfExcept<[EnumConstraint] TEnumType>(params TEnumType[] except)
		{
			Type enumType = typeof(TEnumType);

			return Enum.GetValues(enumType).Cast<TEnumType>()
				.Except(except);
		}

		public static IDictionary<TKey, string> DictionaryOf<TKey, [EnumConstraint] TEnumValue>(
			DisplayType displayType = DisplayType.Value)
		where TKey : struct 
		{
			Type enumType = typeof(TEnumValue);

			IEnumerable<TEnumValue> enumValues = Of<TEnumValue>();

			return enumValues.ToDictionary(enumValue => (TKey)Convert.ChangeType(enumValue, typeof(TKey))
				, enumValue => EnumConverter.ToString(enumValue, displayType));
		}

	}
}