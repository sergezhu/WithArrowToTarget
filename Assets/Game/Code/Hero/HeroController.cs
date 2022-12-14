namespace Game.Code.Hero
{
	using Game.Code.Configs;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;

	public class HeroController : IService
	{
		private IHeroView _view;
		private HeroConfig _heroConfig;
		private TouchControl _touchControl;

		public HeroController( IHeroView view, HeroConfig heroConfig, TouchControl touchControl )
		{
			_view = view;
			_heroConfig = heroConfig;
			_touchControl = touchControl;
		}
	}
}