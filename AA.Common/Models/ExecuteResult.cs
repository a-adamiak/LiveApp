using System;
using System.Collections.Generic;

namespace AAS.Common.Models
{
	public class ExecuteResult
	{
		public ExecuteResult(bool isSuccessful)
		{
			IsSuccessful = isSuccessful;
			Exceptions = new List<Exception>();
		}

		public ExecuteResult(bool isSuccessful, IEnumerable<Exception> exceptions)
		{
			this.IsSuccessful = isSuccessful;
			Exceptions = new List<Exception>(exceptions);
		}

		public ICollection<Exception> Exceptions { get; protected set; }
		public bool IsSuccessful { get; protected set; }

		public void AddException(Exception e)
		{
			Exceptions.Add(e);
		}
	}
}