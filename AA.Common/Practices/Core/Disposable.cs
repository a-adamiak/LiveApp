using System;

namespace AAS.Common.Practices.Core
{
	public abstract class Disposable : IDisposable
	{
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~Disposable()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			ReleaseUnmanagedMemory();
			if (disposing) ReleaseManagedMemory();
		}

		public abstract void ReleaseUnmanagedMemory();
		public abstract void ReleaseManagedMemory();
	}
}