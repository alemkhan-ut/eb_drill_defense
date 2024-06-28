using System;
using UnityEngine.UI;

namespace MadSnail.Common
{
	public static class BaseEventContainer
	{
		public static SceneOnChangedEvent SceneOnChangedEvent = new SceneOnChangedEvent();
		public static SimpleButtonOnClickedEvent SimpleButtonOnClickedEvent = new SimpleButtonOnClickedEvent();
	}

	public class SimpleButtonOnClickedEvent : IGameEvent
	{
		public Button Button { get; private set; }
		public Action Action { get; private set; }
	}

	public class SceneOnChangedEvent : IGameEvent
	{
		public Action Action { get; private set; }
	}
}
