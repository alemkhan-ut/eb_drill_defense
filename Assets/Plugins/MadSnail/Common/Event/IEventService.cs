using System;

namespace MadSnail.Common
{
	public interface IEventService
	{
		public void AddListener<T>(Action<T> evt) where T : IGameEvent;
		public void Broadcast(IGameEvent evt);
		public void Clear();
		public void RemoveListener<T>(Action<T> evt) where T : IGameEvent;
	}
}