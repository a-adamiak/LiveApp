namespace AAS.Common.Base.Object
{
	public abstract class Entity<TIdentity>
	{
		public TIdentity Id { get; set; }

		public override bool Equals(object obj)
		{
			Entity<TIdentity> compareTo = obj as Entity<TIdentity>;

			if (ReferenceEquals(this, compareTo)) return true;

			if (ReferenceEquals(null, compareTo)) return false;

			return Id.Equals(compareTo.Id);
		}

		public static bool operator ==(Entity<TIdentity> a, Entity<TIdentity> b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

			return a.Equals(b);
		}

		public static bool operator !=(Entity<TIdentity> a, Entity<TIdentity> b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode() * 907 + Id.GetHashCode();
		}

		public override string ToString()
		{
			return GetType().Name + " [Id=" + Id + "]";
		}
	}
}