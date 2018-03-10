using System;
using System.Threading.Tasks;

namespace AAS.Common.Extensions
{
    public static class TaskExtensions
    {
	    public static Task<TSecondResult> ContinueWithIf<TFirstResult, TSecondResult>(
		    Task<TFirstResult> firstTask,
		    Predicate<TFirstResult> predicate, Func<TSecondResult> secondAsyncFunc)
	    {
			return firstTask.ContinueWith(firstResponse =>
			{
				if (predicate(firstResponse.Result))
				{
					return secondAsyncFunc();
				}

				return default(TSecondResult);
			});
	    }
    }
}
