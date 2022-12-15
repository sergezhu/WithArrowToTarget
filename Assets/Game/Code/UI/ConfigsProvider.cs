namespace Game.Code.UI
{
	using Game.Code.Infrastructure.Services;

	public class UIProvider : IService
	{
		public UIView UIView { get; }

		public UIProvider( UIView uiView )
		{
			UIView = uiView;
		}
	}
}