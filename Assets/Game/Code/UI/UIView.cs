namespace Game.Code.UI
{
	using System;
	using UniRx;
	using UnityEngine;

	public class UIView : MonoBehaviour
	{
		[SerializeField] private RectTransform _noTouchPanel;
		[SerializeField] private FailWindow _failWindow;
		[SerializeField] private WinWindow _winWindow;

		public IObservable<Unit> RestartButtonClick { get; private set; }
		public IObservable<Unit> NextButtonClick { get; private set; }


		public void ShowFailWindow() => _failWindow.Show();
		public void HideFailWindow() => _failWindow.Hide();

		public void ShowWinWindow() => _winWindow.Show();
		public void HideWinWindow() => _winWindow.Hide();

		public void ShowNoTouchPanel() => _noTouchPanel.gameObject.SetActive( true );
		public void HideNoTouchPanel() => _noTouchPanel.gameObject.SetActive( false );

		public void Init()
		{
			RestartButtonClick = _failWindow.RestartButtonClick;
			NextButtonClick = _winWindow.NextLevelButtonClick;
			
			_failWindow.Init();
			_winWindow.Init();
		}
	}
}