namespace Game.Code.Input
{
    using System;
    using Game.Code.Configs;
    using Game.Code.Utilities.Extensions;
    using Game.Input;
    using UniRx;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.InputSystem.EnhancedTouch;

    public class TouchControl
    {
        private IInputManager _inputManager;
        private GameplayConfig _gameplayConfig;

        public TouchControl( IInputManager inputManager, GameplayConfig gameplayConfig )
        {
            _inputManager = inputManager;
            _gameplayConfig = gameplayConfig;
        }

        public ReactiveCommand<Vector2Int> Swipe { get; } = new ReactiveCommand<Vector2Int>();

        
        private Controls.TouchActions TouchActions => _inputManager.Touch;
        private Vector2 TouchPosition => TouchActions.TouchPosition.ReadValue<Vector2>();

        private bool _isTouching;
        private bool _waitTouch;
        private Vector2 _startTouchPos;
        private Vector2Int[] _heroDirections;
        private Task _delayTask;

        public void Initialize()
        {
            EnhancedTouchSupport.Enable();
            TouchSimulation.Enable();

            _delayTask = Task.Delay( TimeSpan.FromMilliseconds( 50 ) );
            
            _inputManager.Touch.TouchPress.SubscribeToPerformed( OnTouchPress );
            _inputManager.Touch.TouchRelease.SubscribeToPerformed( OnTouchRelease );
            _inputManager.Touch.TouchPosition.SubscribeToPerformed( OnPositionChanged );

            _heroDirections = new[] {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
        }

        private void OnTouchPress(InputAction.CallbackContext ctx)
        {
            OnStartTouch(ctx);
        }

        private void OnTouchRelease(InputAction.CallbackContext ctx)
        {
            OnEndTouch(ctx);
        }

        private void OnPositionChanged(InputAction.CallbackContext ctx)
        {
            if (_isTouching == false || _waitTouch)
                return;

            //Debug.Log( $"changed : time {ctx.time}, {TouchPosition}" );
        }

        private void OnStartTouch(InputAction.CallbackContext ctx)
        {
            if(_isTouching)
                return;

            _isTouching = true;

            // New Input System return 0,0 when first time take a value
            // https://forum.unity.com/threads/first-position-of-touch-contact-is-0-0.1039135/
            StartTouchAsync( ctx );
        }

        private async void StartTouchAsync(InputAction.CallbackContext ctx)
        {
            _waitTouch = true;
            await _delayTask;

            _waitTouch = false;
            StartTouchBehaviour(ctx);
        }

        private void StartTouchBehaviour(InputAction.CallbackContext ctx)
        {
            _startTouchPos = TouchPosition;
        }

        private void OnEndTouch(InputAction.CallbackContext ctx)
        {
            if(_isTouching == false)
                return;

            _isTouching = false;

            var endTouchPos = TouchPosition;
            var vector = endTouchPos - _startTouchPos;
            var dir = vector.normalized;

            var deadZone = (Screen.width + Screen.height) * 0.5f * _gameplayConfig.TouchRelativeDeadZone;
            if(vector.magnitude < deadZone)
                return;

            if ( !InSafe( _startTouchPos ) || !InSafe( endTouchPos ) )
                return;
            
            foreach ( var heroDir in _heroDirections )
            {
                var dot = Vector2.Dot( heroDir, dir );
                //Debug.Log( $"heroDir {heroDir}, dir {dir}, dot {dot}" );
                
                if ( dot > 0.75f )
                {
                    //Debug.Log($"heroDir {heroDir}, dot {Vector2.Dot( heroDir, dir )}");
                    Swipe.Execute( heroDir );
                    break;
                }
            }
        }

        private bool InSafe( Vector2 v )
        {
            return _gameplayConfig.TouchZone.InZone( new Vector2(v.x / Screen.width, v.y / Screen.height) );
        }
    }
}