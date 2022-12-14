namespace Game.Code.Infrastructure
{
	using Game.Code.Configs;
	using Game.Code.Hero;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using UnityEngine;

	public class LevelBootstrap : MonoBehaviour
	{
		[SerializeField] private HeroView _heroView;
		
		private HeroController _heroController;

		private void Awake()
		{
			Bind();
		}

		private void Bind()
		{
			var rootConfig = AllServices.Container.Single<ConfigsProvider>().RootConfig;
			var touchControl = AllServices.Container.Single<TouchControl>();

			_heroController = new HeroController( _heroView, rootConfig.Hero, touchControl );
			AllServices.Container.RegisterSingle( _heroController );
			
			
		}
	}
}
