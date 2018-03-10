using System;
using System.Threading.Tasks;
using NullGuard;
using RestSharp;
using RestSharp.Serializers;

namespace AAS.Common.Helpers.Rest
{
	public class RestSharpService : IRestService
	{
		protected ISerializer restSharpSerializer;

		public RestSharpService([AllowNull] ISerializer restSharpSerializer)
		{
			this.restSharpSerializer = restSharpSerializer;
		}

		public Task<TResult> ExecutePostAsync<TResult>(Uri apiAddress, Uri actionAddress, object body)
		{
			if (typeof(TResult) != typeof(IRestResponse))
			{
				throw new InvalidCastException($"Type of the result should be IRestResponse. Cannot convert from {typeof(TResult).Name}");
			}

			RestClient client  = new RestClient(apiAddress);
			RestRequest request = new RestRequest(actionAddress, Method.POST);

			if (this.restSharpSerializer != null)
			{
				request.JsonSerializer = restSharpSerializer;
			}

			request.AddJsonBody(body);

			Task<IRestResponse> result = client.ExecutePostTaskAsync(request);

			return result as Task<TResult>;
		}
	}
}