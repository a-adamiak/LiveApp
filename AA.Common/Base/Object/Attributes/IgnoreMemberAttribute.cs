using System;

namespace AAS.Common.Base.Object.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class IgnoreMemberAttribute : Attribute
	{
	}
}