namespace Game.Code.UI
{
	using System;
	using Game.Code.Core.Game_Control;
	using Game.Code.Enums;
	using Game.Code.Hero;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using UniRx;
	using UnityEngine;

	public class UIController : IService
	{
		private readonly UIView _view;
		private readonly HeroController _heroController;
		private readonly ScenesManager _sceneManager;
		private readonly TouchControl _touchControl;
		private readonly CompositeDisposable _disposable;

		private int _openedWindowsCount;

		public UIController( UIView view, HeroController heroController, ScenesManager sceneManager, TouchControl touchControl )
		{
			_view = view;
			_heroController = heroController;
			_sceneManager = sceneManager;
			_touchControl = touchControl;

			_disposable = new CompositeDisposable();
		}

		public void Initialize()
		{
			HideAll();
			
			_heroController.State
				.Subscribe( s => OnStateChanged( s ) )
				.AddTo( _disposable );

			_view.RestartButtonClick
				.Subscribe( _ => OnRestartButtonClick() )
				.AddTo( _disposable );

			_view.NextButtonClick
				.Subscribe( _ => OnNextButtonClick() )
				.AddTo( _disposable );

			_view.SomeWindowHidden
				.Subscribe( _ =>
				{
					_openedWindowsCount = Mathf.Max( 0, _openedWindowsCount - 1 );
					_touchControl.SetTouchLock( _openedWindowsCount > 0 );
				} )
				.AddTo( _disposable );

			_view.SomeWindowShown
				.Subscribe( _ =>
				{
					_openedWindowsCount += 1;
					_touchControl.SetTouchLock( _openedWindowsCount > 0 );
				} )
				.AddTo( _disposable );
		}

		private void OnStateChanged( EHeroState state )
		{
			switch ( state )
			{
				case EHeroState.Crashed:
					_view.ShowNoTouchPanel();
					_view.ShowFailWindow();
					break;
				case EHeroState.Finished:
					_view.ShowNoTouchPanel();
					_view.ShowWinWindow();
					break;
			}
		}

		private void OnRestartButtonClick()
		{
			HideAll();
			_disposable.Clear();
			_sceneManager.ReloadLevelScene();
		}
		
		private void OnNextButtonClick()
		{
			HideAll();
			_disposable.Clear();
			_sceneManager.LoadNextLevelScene();
		}

		private void HideAll()
		{
			_view.HideNoTouchPanel();
			_view.HideFailWindow();
			_view.HideWinWindow();

			_openedWindowsCount = 0;
		}
	}
}