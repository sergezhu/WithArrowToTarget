namespace Game.Code.Hero
{
	using System.Linq;
	using DG.Tweening;
	using Game.Code.Configs;
	using Game.Code.Enums;
	using Game.Code.Gameplay;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using Game.Code.Utilities.Extensions;
	using UniRx;
	using UnityEngine;

	public class HeroController : IService
	{
		private readonly IHeroView _view;
		private readonly HeroConfig _heroConfig;
		private readonly TouchControl _touchControl;
		private readonly FinishZone _finishZone;
		private readonly Collider[] _hitColliders;

		private readonly LayerMask _obstaclesMask;
		private readonly LayerMask _finishZoneMask;
		private readonly CompositeDisposable _disposables;
		
		private Tween _moveTween;
		private Vector3 _moveFrom;
		private Vector3 _moveTo;

		public ReactiveProperty<EHeroState> State { get; }
		
		private bool TouchWhenMoving { get; set; }

		public HeroController( IHeroView view, HeroConfig heroConfig, TouchControl touchControl, ObstaclesContainer obstaclesContainer, FinishZone finishZone )
		{
			_view = view;
			_heroConfig = heroConfig;
			_touchControl = touchControl;
			_finishZone = finishZone;
			_hitColliders = new Collider[obstaclesContainer.Colliders.ToArray().Length];

			_obstaclesMask = 1 << Layers.Obstacles;
			_finishZoneMask = 1 << Layers.Finish;

			State = new ReactiveProperty<EHeroState>( EHeroState.Idle );
			
			_disposables = new CompositeDisposable();
		}

		public void Initialize()
		{
			ResetArrow();

			_touchControl.TouchStart
				.Subscribe( v => { OnTouchStart(); } )
				.AddTo( _disposables );

			_touchControl.TouchEnd
				.Where( _ => State.Value == EHeroState.Idle)
				.Subscribe( v => { OnTouchEnd(); } )
				.AddTo( _disposables );

			_touchControl.DirectionFromStart
				.Subscribe( v => OnChangeDirection( v ) )
				.AddTo( _disposables );
		}

		private void OnTouchStart()
		{
			if ( State.Value == EHeroState.Move )
			{
				TouchWhenMoving = true;
			}
			else if( State.Value == EHeroState.Idle )
			{
				_view.SetArrowDir( Vector3.zero );
				_view.ShowArrow();
			}
		}

		private void OnTouchEnd()
		{
			if ( State.Value == EHeroState.Idle )
			{
				MoveTo( _view.Arrow.EndPosition );
				_view.HideArrow();
			}

			TouchWhenMoving = false;
		}

		private void MoveTo( Vector3 to )
		{
			State.Value = EHeroState.Move;
			
			_moveTween?.Kill();
			_moveFrom = _view.Position;
			_moveTo = to;

			_moveTween = DOVirtual
				.Float( 0, 1f, _heroConfig.MoveDuration, value =>
				{
					var pos = Vector3.Lerp( _moveFrom, _moveTo, value );
					_view.Position = pos;

					if ( HasHeroOverlappedObstacles( _hitColliders ) )
					{
						_moveTween.Kill();
						_moveTween = null;
						State.Value = EHeroState.Crashed;
						
						_view.SetCrashedState();
					}
					else if ( HasHeroOverlappedFinishZone( _hitColliders ) )
					{
						State.Value = EHeroState.Finished;
						_view.SetFinishedState();
					}
				} )
				.SetEase( Ease.OutQuad )
				.OnComplete( () =>
				{
					State.Value = EHeroState.Idle;
					_moveTween = null;
				} );
		}

		private void OnChangeDirection( Vector2 direction )
		{
			if(State.Value != EHeroState.Idle || TouchWhenMoving)
				return;
			
			var arrowDirection = direction * _heroConfig.ArrowLengthMultiplier / Screen.width;
			_view.SetArrowDir( arrowDirection );

			var arrowEndOverlap = HasArrowOverlappedObstacles( _hitColliders);
			_view.SetArrowOverlapState( arrowEndOverlap );
		}

		private void ResetArrow()
		{
			_view.HideArrow();
			_view.SetArrowMaxSize( _heroConfig.ArrowMaxSize );
			_view.SetArrowDir( Vector3.zero );
			_view.SetArrowOverlapState( false );
		}

		private bool HasArrowOverlappedObstacles( Collider[] colliders )
		{
			var halfSize = 0.5f * _view.Arrow.BodySize.WithY( _view.Size );
			
			var overlappedArrowCount = Physics.OverlapSphereNonAlloc( _view.Arrow.EndPosition, _view.GetRadius(), colliders, _obstaclesMask );
			var overlappedBodyCount = Physics.OverlapBoxNonAlloc( _view.Arrow.BodyCenter, halfSize, colliders, _view.Arrow.Transform.rotation, _obstaclesMask );
			
			return overlappedArrowCount > 0 || overlappedBodyCount > 0;
		}

		private bool HasHeroOverlappedObstacles( Collider[] colliders )
		{
			var overlappedCount = Physics.OverlapSphereNonAlloc( _view.Position, _view.GetRadius(), colliders, _obstaclesMask );
			return overlappedCount > 0;
		}

		private bool HasHeroOverlappedFinishZone( Collider[] colliders )
		{
			var overlappedCount = Physics.OverlapSphereNonAlloc( _view.Position, _view.GetRadius(), colliders, _finishZoneMask );
			return overlappedCount > 0;
		}
	}
}