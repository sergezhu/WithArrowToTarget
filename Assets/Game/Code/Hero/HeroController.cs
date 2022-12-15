namespace Game.Code.Hero
{
	using System.Linq;
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
			_view.HideArrow();
			_view.SetArrowMaxSize( _heroConfig.ArrowMaxSize );
			_view.SetArrowDir( Vector3.zero );
			_view.SetArrowOverlapState( false );
			
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
			Debug.Log( $"{direction}, r : {_view.GetRadius()}" );
			_view.SetArrowDir( direction * _heroConfig.ArrowLengthMultiplier / Screen.width );

			var arrowEndOverlap = HasOverlappedObstacles( _hitColliders);
			_view.SetArrowOverlapState( arrowEndOverlap );
		}

		private bool HasOverlappedObstacles( Collider[] colliders )
		{
			var overlappedArrowCount = Physics.OverlapSphereNonAlloc( _view.Arrow.EndPosition, _view.GetRadius(), colliders, _obstaclesMask );
			var overlappedBodyCount = Physics.OverlapBoxNonAlloc( _view.Arrow.BodyPosition, _view.Arrow.BodySize, colliders, _view.Arrow.BodyRotation, _obstaclesMask );
			
			return overlappedArrowCount > 0 || overlappedBodyCount > 0;
		}
	}
}