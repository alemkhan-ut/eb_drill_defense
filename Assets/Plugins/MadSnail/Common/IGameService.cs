using System;
using UnityEngine;

namespace MadSnail.Common
{
	public interface IGameService
	{
		public Player Player { get; }
		public bool IsAuthenticated { get; }

		public event Action<bool> OnAuthenticatedEvent;
		public bool IsPortrait { get; }
		public bool IsMobile { get; }
		public abstract DateTime ServerTime { get; }
		public void Authenticate();
		public void AuthenticatedOnFailedHandler();
		public void AuthenticatedOnSuccessfullyHandler();
		public void LoadPlayerData();
	}

	public class Player
	{
		public string Name;
		public Sprite Avatar;

		public string DefaultName => $"ID: {UnityEngine.Random.Range(0, 9999999).ToString("D7")}";
		public Sprite DefaultAvatarSprite => Sprite.Create(new Texture2D(2, 2), new Rect(), new Vector2());
	}
}