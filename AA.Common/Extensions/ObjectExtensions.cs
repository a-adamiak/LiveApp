using System;
using System.Globalization;
using AAS.Common.Practices.Option;
using NullGuard;

namespace AAS.Common.Extensions
{
	public static class ObjectExtensions
	{
		public static void SetPropertyValue<TType>(this object obj, string propertyName, [AllowNull] TType value)
		{
			obj.GetType().GetProperty(propertyName)?.SetValue(obj, value, null);
		}

		public static Option<TType> GetPropertyValue<TType>(this object obj, string propertyName)
		{
			object baseValue = obj.GetType().GetProperty(propertyName)?.GetValue(obj);

			return (TType) Convert.ChangeType(baseValue, typeof(TType));

		}

		public static bool IsNumeric(this object obj)
		{
			return double.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), NumberStyles.Any,
				NumberFormatInfo.InvariantInfo, out double number);
		}
	}
}