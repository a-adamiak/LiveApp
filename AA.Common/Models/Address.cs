using NullGuard;

namespace AAS.Common.Models
{
	public class Address
	{
		public Address(string addressLine1, string city, string postalCode, string country,
			[AllowNull] string addressLine2 = null)
		{
			AddressLine1 = addressLine1;
			City = city;
			PostalCode = postalCode;
			Country = country;
			AddressLine2 = addressLine2;
		}

		public string AddressLine1 { get; }

		public string AddressLine2 { get; }

		public string City { get; }

		public string PostalCode { get; }
		public string Country { get; }
	}
}