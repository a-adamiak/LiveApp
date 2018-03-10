using System;
using System.Collections.Generic;
using System.Threading;
using AAS.Common.Models;
using AAS.Common.Practices.Option;
using NullGuard;

namespace AAS.Common.Helpers
{
	public static class Execute
	{
		public static ExecuteResult WithOnFailureRepetition(Action actionToExecute,
			Option<Action<Exception, int>> onSingleError,
			int repetitionsNumber = 2,
			int waitingMs = 1000)
		{
			List<Exception> exceptions = new List<Exception>();
			int errorsCounter = 0;
			while (errorsCounter <= repetitionsNumber)
				try
				{
					actionToExecute();
					return new ExecuteResult(true, exceptions);
				}
				catch (Exception e)
				{
					exceptions.Add(e);
					++errorsCounter;
					if (onSingleError.HasValue)
					{
						onSingleError.Value(e, errorsCounter);
					}

					Thread.Sleep(waitingMs);
				}

			return new ExecuteResult(false, exceptions);
		}
	}
}