using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace AAS.Common.Helpers.Serialization
{
	public class NewtonsonJsonSerializer : ISerializer
	{
		public NewtonsonJsonSerializer()
		{
			ContentType = "application/json";
		}

		public string Serialize(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public string RootElement { get; set; }

		public string Namespace { get; set; }

		public string DateFormat { get; set; }

		public string ContentType { get; set; }
	}
}
