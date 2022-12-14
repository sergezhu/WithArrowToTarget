namespace Game.Code.Hero
{
	using System;
	using System.Collections.Generic;
	using Game.Code.Configs;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using UniRx;
	using UnityEngine;

	public class HeroController : IService
	{
		private IHeroView _view;
		private HeroConfig _heroConfig;
		private TouchControl _touchControl;
		private CompositeDisposable _disposables;

		public HeroController( IHeroView view, HeroConfig heroConfig, TouchControl touchControl )
		{
			_view = view;
			_heroConfig = heroConfig;
			_touchControl = touchControl;
			_disposables = new CompositeDisposable();
		}

		public void Initialize()
		{
			_view.HideArrow();
			_view.SetArrowMaxSize( _heroConfig.ArrowMaxSize );
			_view.SetArrowDir( Vector3.zero );
			
			_touchControl.TouchStart
				.Subscribe( v => _view.ShowArrow() )
				.AddTo( _disposables );

			_touchControl.TouchEnd
				.Subscribe( v =>
				{
					_view.HideArrow();
					_view.SetArrowDir( Vector3.zero );
				} )
				.AddTo( _disposables );

			_touchControl.DirectionFromStart
				.Subscribe( v => OnChangeDirection( v ) )
				.AddTo( _disposables );
		}

		private void OnChangeDirection( Vector2 direction )
		{
			Debug.Log( $"{direction}" );
			_view.SetArrowDir( direction * _heroConfig.ArrowLengthMultiplier / Screen.width );
		}
	}
}