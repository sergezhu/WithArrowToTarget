namespace Game.Code.UI
{
	using System;
	using Game.Code.UI.UIWindow;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;

	public class WinWindow : BaseUIWindow
	{
		[SerializeField] private Button _nextLevelButton;

		public IObservable<Unit> NextLevelButtonClick { get; private set; }

		public override void Init()
		{
			NextLevelButtonClick = _nextLevelButton.onClick.AsObservable();
		}
	}
}