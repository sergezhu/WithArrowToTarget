namespace Game.Code.Input
{
    using Game.Input;

    public interface IInputManager
    {
        Controls.TouchActions Touch { get; }
        Controls.KeyboardActions Keyboard { get; }
    }


    public class InputManager : IInputManager
    {
        private Controls _controls;

        public Controls.TouchActions Touch { get; private set; }
        public Controls.KeyboardActions Keyboard { get; private set; }
        
        public void Initialize()
        {
            _controls = new Controls();
            
            Touch = _controls.Touch;
            Keyboard = _controls.Keyboard;
            
            Touch.Enable();
        }
    }
}