namespace Game.Code.Input
{
    using Game.Input;

    public class KeyboardControl
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