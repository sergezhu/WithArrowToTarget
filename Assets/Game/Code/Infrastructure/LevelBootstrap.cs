namespace Game.Code.Infrastructure
{
	using Game.Code.Configs;
	using Game.Code.Core.Game_Control;
	using Game.Code.Gameplay;
	using Game.Code.Hero;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using Game.Code.UI;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class LevelBootstrap : MonoBehaviour
	{
		[SerializeField] private HeroView _heroView;
		[SerializeField] private ObstaclesContainer _obstaclesContainer;
		[SerializeField] private FinishZone _finishZone;
		
		private HeroController _heroController;
		private UIController _uiController;

		private void Awake()
		{
			Bind();
		}

		private void Bind()
		{
			var rootConfig = AllServices.Container.Single<ConfigsProvider>().RootConfig;
			var touchControl = AllServices.Container.Single<TouchControl>();
			var uiProvider = AllServices.Container.Single<UIProvider>();
			var sceneManager = AllServices.Container.Single<ScenesManager>();

			_heroController = new HeroController( _heroView, rootConfig.Hero, touchControl, _obstaclesContainer, _finishZone );
			_heroController.Initialize();
			AllServices.Container.RegisterSingle( _heroController );

			_uiController = new UIController( uiProvider.UIView, _heroController, sceneManager, touchControl);
			_uiController.Initialize();
			AllServices.Container.RegisterSingle( _uiController );
		}
	}
}
