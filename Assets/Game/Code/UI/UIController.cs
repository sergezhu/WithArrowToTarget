namespace Game.Code.UI
{
	using System;
	using Game.Code.Core.Game_Control;
	using Game.Code.Enums;
	using Game.Code.Hero;
	using Game.Code.Infrastructure.Services;
	using UniRx;

	public class UIController : IService
	{
		private readonly UIView _view;
		private readonly HeroController _heroController;
		private readonly ScenesManager _sceneManager;
		private readonly CompositeDisposable _disposable;

		public UIController( UIView view, HeroController heroController, ScenesManager sceneManager )
		{
			_view = view;
			_heroController = heroController;
			_sceneManager = sceneManager;

			_disposable = new CompositeDisposable();
		}

		public void Initialize()
		{
			HideAll();
			
			_heroController.State
				.Subscribe( s => OnStateChanged( s ) )
				.AddTo( _disposable );

			_view.RestartButtonClick
				.Subscribe( _ =>
				{
					HideAll();
					_sceneManager.ReloadLevelScene();
				} )
				.AddTo( _disposable );

			_view.RestartButtonClick
				.Subscribe( _ =>
				{
					HideAll();
					_sceneManager.LoadNextLevelScene();
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

		private void HideAll()
		{
			_view.HideNoTouchPanel();
			_view.HideFailWindow();
			_view.HideWinWindow();
		}
	}
}