namespace Game.Code.Infrastructure
{
	using Game.Code.Configs;
	using Game.Code.Infrastructure.Services;
	using Game.Code.Input;
	using UnityEngine;

	public class MainBootstrap : MonoBehaviour
	{
		[SerializeField] private RootConfig _rootConfig;
		
		private ConfigsProvider _configsProvider;
		private InputManager _inputManager;
		private TouchControl _touchControl;
		private KeyboardControl _keyboardControl;

		private void Awake()
		{
			DontDestroyOnLoad( this.gameObject );
			Bind();
		}

		private void Bind()
		{
			_configsProvider = new ConfigsProvider( _rootConfig );
			AllServices.Container.RegisterSingle( _configsProvider );
			
			BindInput();
		}

		private void BindInput()
		{
			_inputManager = new InputManager();
			_inputManager.Initialize();

			_touchControl = new TouchControl( _inputManager, _rootConfig.Gameplay );
			_touchControl.Initialize();
			AllServices.Container.RegisterSingle( _touchControl );

			_keyboardControl = new KeyboardControl( _inputManager );
			_keyboardControl.Initialize();
			AllServices.Container.RegisterSingle( _keyboardControl );
		}
	}
}
