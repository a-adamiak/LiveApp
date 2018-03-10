using System;
using System.Linq;
using System.Reflection;
using ExtraConstraints;

namespace AAS.Common.Extensions
{
	public static class EnumExtensions
	{
		public static TAttribute GetEnumAttribute<[EnumConstraint] TEnum, TAttribute>(this TEnum value)
			where TAttribute : Attribute
		{
			return value.GetType()
				.GetMember(value.ToString())
				.First()
				.GetCustomAttribute<TAttribute>();
		}
	}
}