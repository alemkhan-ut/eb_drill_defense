using System;


namespace MadSnail.Common
{
	public interface ISaveService<T> where T : IGameData
	{
		public event Action OnDataLoadedFinishEvent;
		public T Data { get; }

		public void SaveData();
		public void LoadData();
		public void EraseSave();
	}
}