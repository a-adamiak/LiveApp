using AAS.Common.Practices.Core;

namespace AAS.Common.Helpers
{
	public abstract class ValidationMonitor : Disposable
	{
		public void Enter()
		{
			Validate();
			OnEnter();
		}

		protected abstract void Validate();
		protected abstract void OnEnter();

	}
}