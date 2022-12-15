namespace Game.Code.Gameplay
{
	using System.Collections.Generic;
	using Game.Code.Configs;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Utilities.Extensions;
	using UnityEngine;

	public class ObstaclesController : IService
	{
		private ObstaclesContainer _container;
		private readonly GameplayConfig _gameplayConfig;

		public IEnumerable<Collider> Colliders => _container.Colliders;
		public IEnumerable<MeshRenderer> Renderers => _container.Renderers;

		public ObstaclesController( ObstaclesContainer container, GameplayConfig gameplayConfig )
		{
			_container = container;
			_gameplayConfig = gameplayConfig;
		}

		public void SetCrashedState()
		{
			Renderers.ForEach( r => r.sharedMaterial = _gameplayConfig.ObstaclesCrashMaterial );
		}
	}
}