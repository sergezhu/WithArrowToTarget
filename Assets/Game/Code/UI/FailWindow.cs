namespace Game.Code.UI
{
	using System;
	using Game.Code.UI.UIWindow;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;

	public class FailWindow : BaseUIWindow
	{
		[SerializeField] private Button _restartButton;

		public IObservable<Unit> RestartButtonClick { get; private set; }

		public override void Init()
		{
			RestartButtonClick = _restartButton.onClick.AsObservable();
		}
	}
}