namespace Game.Code.Core.Game_Control
{
	using System;
	using System.Linq;
	using Game.Code.Configs;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Utilities.Extensions;
	using UniRx;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class ScenesManager : IService, IDisposable
	{

		private LevelScenesConfig _levelScenesConfig;

		private readonly CompositeDisposable _lifetimeDisposables = new CompositeDisposable();

		public ScenesManager( LevelScenesConfig levelScenesConfig )
		{
			_levelScenesConfig = levelScenesConfig;
			LevelNumber = 1;
		}

		private int LevelNumber { get; set; }

		public void Initialize()
		{
			#if UNITY_EDITOR
			UnloadAlreadyLoadedLevelsScenes();
			#endif
		}

		public void Dispose() => _lifetimeDisposables.Clear();

		private void UnloadAlreadyLoadedLevelsScenes()
		{
			_levelScenesConfig.Levels
				.Where( scene => SceneManager.GetSceneByName( scene.SceneName ).isLoaded )
				.ForEach( scene => UnloadScene(scene.SceneName) );
		}

		public void LoadLevelScene()
		{
			var levelSceneName = GetCurrentLevelSceneName();
			var isAlreadyLoaded = SceneManager.GetSceneByName( levelSceneName ).isLoaded;

			Debug.Log( $"LOAD LEVEL SCENE : {levelSceneName}" );

			if ( isAlreadyLoaded )
				return;
			
			LoadScene( levelSceneName );

			Observable
				.NextFrame()
				.Subscribe( _ =>
				{
					SetActiveScene();
				} )
				.AddTo( _lifetimeDisposables );
		}

		public void UnloadLevelScene()
		{
			UnloadScene( GetCurrentLevelSceneName() );
		}

		public void ReloadLevelScene()
		{
			UnloadLevelScene();
			LoadLevelScene();
		}

		public void LoadNextLevelScene()
		{
			UnloadLevelScene();
			LevelNumber = LevelNumber % _levelScenesConfig.Levels.Count + 1;
			LoadLevelScene();
		}

		private void SetActiveScene()
		{
			var currentScene = SceneManager.GetSceneByName( GetCurrentLevelSceneName() );
			SceneManager.SetActiveScene( currentScene );
		}

		private string GetCurrentLevelSceneName()
		{
			var levelScene = _levelScenesConfig.Levels[GetLevelSceneIndex()];
			
			return levelScene.SceneName;
		}

		private int GetLevelSceneIndex()
		{
			return (LevelNumber - 1) % _levelScenesConfig.Levels.Count;
		}

		private void LoadScene( string sceneName )
		{
			SceneManager.LoadScene( sceneName, LoadSceneMode.Additive );
		}

		private void UnloadScene( string sceneName )
		{
			var scene = SceneManager.GetSceneByName( sceneName );

			if ( scene.isLoaded == false )
			{
				Debug.LogWarning( $"Unload is ignored because scene {sceneName} is not loaded" );
				return;
			}

			SceneManager.UnloadSceneAsync( sceneName );
		}
	}
}

