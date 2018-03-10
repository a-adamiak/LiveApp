using System;

namespace AAS.Common.Extensions
{
	public static class ExceptionExtensions
	{
		public static string GetDeepestMessage(this Exception exception)
		{
			Exception currentException = exception;
			while (currentException.HasInnerException()) currentException = exception.InnerException;

			return currentException.Message ?? string.Empty;
		}

		public static bool HasInnerException(this Exception exception)
		{
			return exception.InnerException != null;
		}
	}
}