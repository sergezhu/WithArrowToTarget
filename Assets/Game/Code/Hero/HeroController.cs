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
			_touchControl.IsTouching
				.Subscribe( v => OnIsTouchingChanged(v) )
				.AddTo( _disposables );

			_touchControl.DirectionFromStart
				.Subscribe( v => OnChangeDirection( v ) )
				.AddTo( _disposables );
		}

		private void OnChangeDirection( Vector2 direction )
		{
			_view.SetArrowDir( direction * _heroConfig.ArrowLengthMultiplier );
		}

		private void OnIsTouchingChanged(bool isTouch)
		{
			if(isTouch)
				_view.ShowArrow();
			else
				_view.HideArrow();
		}
	}
}