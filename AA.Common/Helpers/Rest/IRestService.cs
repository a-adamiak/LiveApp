using System;
using System.Threading.Tasks;

namespace AAS.Common.Helpers.Rest
{
	public interface IRestService
	{
		Task<TResult> ExecutePostAsync<TResult>(Uri apiAddress, Uri actionAddress, object body);
	}
}