using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AAS.Common.Base.Object.Attributes;
using NullGuard;

namespace AAS.Common.Base.Object
{
	public abstract class ValueObject : IEquatable<ValueObject>
	{
		private List<FieldInfo> fields;
		private List<PropertyInfo> properties;

		public bool Equals([AllowNull]  ValueObject obj)
		{
			return Equals(obj as object);
		}

		public static bool operator ==([AllowNull] ValueObject obj1, [AllowNull]  ValueObject obj2)
		{
			if (Equals(obj1, null))
			{
				if (Equals(obj2, null)) return true;
				return false;
			}

			return obj1.Equals(obj2);
		}

		public static bool operator !=([AllowNull]  ValueObject obj1, [AllowNull]  ValueObject obj2)
		{
			return !(obj1 == obj2);
		}

		public override bool Equals([AllowNull]  object obj)
		{
			if (obj == null || GetType() != obj.GetType()) return false;

			return GetProperties().All(p => PropertiesAreEqual(obj, p))
			       && GetFields().All(f => FieldsAreEqual(obj, f));
		}

		private bool PropertiesAreEqual([AllowNull]  object obj, PropertyInfo p)
		{
			return Equals(p.GetValue(this, null), p.GetValue(obj, null));
		}

		private bool FieldsAreEqual([AllowNull]  object obj, FieldInfo f)
		{
			return Equals(f.GetValue(this), f.GetValue(obj));
		}

		private IEnumerable<PropertyInfo> GetProperties()
		{
			if (properties == null)
				properties = GetType()
					.GetProperties(BindingFlags.Instance | BindingFlags.Public)
					.Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
					.ToList();

			return properties;
		}

		private IEnumerable<FieldInfo> GetFields()
		{
			if (fields == null)
				fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
					.Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
					.ToList();

			return fields;
		}

		public override int GetHashCode()
		{
			unchecked //allow overflow
			{
				int hash = 17;
				foreach (PropertyInfo prop in GetProperties())
				{
					object value = prop.GetValue(this, null);
					hash = HashValue(hash, value);
				}

				foreach (FieldInfo field in GetFields())
				{
					object value = field.GetValue(this);
					hash = HashValue(hash, value);
				}

				return hash;
			}
		}

		private int HashValue(int seed, [AllowNull]  object value)
		{
			int currentHash = value?.GetHashCode() ?? 0;

			return seed * 23 + currentHash;
		}
	}
}