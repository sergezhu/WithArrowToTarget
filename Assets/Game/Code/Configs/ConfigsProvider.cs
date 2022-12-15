namespace Game.Code.Configs
{
	using Game.Code.Infrastructure.Services;

	public class ConfigsProvider : IService
	{
		public RootConfig RootConfig { get; }

		public ConfigsProvider( RootConfig rootConfig )
		{
			RootConfig = rootConfig;
		}
	}
}