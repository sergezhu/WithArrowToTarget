namespace Game.Code.Hero
{
	using System.Linq;
	using DG.Tweening;
	using Game.Code.Configs;
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
		private readonly Collider[] _obstaclesColliders;
		private readonly Collider[] _hitColliders;

		private readonly LayerMask _obstaclesMask;
		private readonly CompositeDisposable _disposables;
		
		private Tween _moveTween;
		private Vector3 _moveFrom;
		private Vector3 _moveTo;

		private bool IsMoving { get; set; }
		private bool TouchWhenMoving { get; set; }

		public HeroController( IHeroView view, HeroConfig heroConfig, TouchControl touchControl, ObstaclesContainer obstaclesContainer )
		{
			_view = view;
			_heroConfig = heroConfig;
			_touchControl = touchControl;
			_obstaclesColliders = obstaclesContainer.Colliders.ToArray();
			_hitColliders = new Collider[_obstaclesColliders.Length];

			_obstaclesMask = 1 << Layers.Obstacles;
			_disposables = new CompositeDisposable();
		}

		public void Initialize()
		{
			ResetArrow();

			_touchControl.TouchStart
				.Subscribe( v =>
				{
					if ( IsMoving )
						TouchWhenMoving = true;
					else
					{
						_view.SetArrowDir( Vector3.zero );
						_view.ShowArrow();
					}
				} )
				.AddTo( _disposables );

			_touchControl.TouchEnd
				.Where( _ => !IsMoving)
				.Subscribe( v =>
				{
					if ( !TouchWhenMoving )
					{
						MoveTo( _view.Arrow.EndPosition );
						_view.HideArrow();
					}

					TouchWhenMoving = false;
				} )
				.AddTo( _disposables );

			_touchControl.DirectionFromStart
				.Subscribe( v => OnChangeDirection( v ) )
				.AddTo( _disposables );
		}

		private void MoveTo( Vector3 to )
		{
			IsMoving = true;
			
			_moveTween?.Kill();
			_moveFrom = _view.Position;
			_moveTo = to;

			_moveTween = DOVirtual
				.Float( 0, 1f, _heroConfig.MoveDuration, value =>
				{
					var pos = Vector3.Lerp( _moveFrom, _moveTo, value );
					Debug.Log( $"from {_moveFrom}, to {_moveTo}, current {pos}, v {value}" );
					_view.Position = pos;
				} )
				.SetEase( Ease.OutQuad )
				.OnComplete( () =>
				{
					IsMoving = false;
					_moveTween = null;
				} );
		}

		private void OnChangeDirection( Vector2 direction )
		{
			if(IsMoving || TouchWhenMoving)
				return;
			
			var arrowDirection = direction * _heroConfig.ArrowLengthMultiplier / Screen.width;
			_view.SetArrowDir( arrowDirection );

			var arrowEndOverlap = HasOverlappedObstacles( _hitColliders);
			_view.SetArrowOverlapState( arrowEndOverlap );
		}

		private void ResetArrow()
		{
			_view.HideArrow();
			_view.SetArrowMaxSize( _heroConfig.ArrowMaxSize );
			_view.SetArrowDir( Vector3.zero );
			_view.SetArrowOverlapState( false );
		}

		private bool HasOverlappedObstacles( Collider[] colliders )
		{
			var halfSize = 0.5f * _view.Arrow.BodySize.WithY( _view.Size );
			
			var overlappedArrowCount = Physics.OverlapSphereNonAlloc( _view.Arrow.EndPosition, _view.GetRadius(), colliders, _obstaclesMask );
			var overlappedBodyCount = Physics.OverlapBoxNonAlloc( _view.Arrow.BodyCenter, halfSize, colliders, _view.Arrow.Transform.rotation, _obstaclesMask );
			
			//return overlappedArrowCount > 0 || overlappedBodyCount > 0;
			return overlappedBodyCount > 0;
		}
	}
}