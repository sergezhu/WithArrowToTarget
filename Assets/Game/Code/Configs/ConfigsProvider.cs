namespace Game.Code.Configs
{
	using Game.Code.Infrastructure.Services;

	public class ConfigsProvider : IService
	{
		public RootConfig RootConfig { get; private set; }

		public ConfigsProvider( RootConfig rootConfig )
		{
			RootConfig = rootConfig;
		}
	}
}