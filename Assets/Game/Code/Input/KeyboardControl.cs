namespace Game.Code.Input
{
    using Game.Code.Infrastructure.Services;
    using Game.Input;

    public class KeyboardControl : IService
    {
        private IInputManager _inputManager;


        public KeyboardControl( IInputManager inputManager )
        {
            _inputManager = inputManager;
        }

        private Controls.KeyboardActions KeyboardActions => _inputManager.Keyboard;


        public void Initialize()
        {
        }
    }
}