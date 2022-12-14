//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Game/Data/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Input
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""027526c5-59f0-46bd-8768-246a666b036b"",
            ""actions"": [
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cb4d1c87-93f6-4aa6-9087-b149f25ac878"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchStartPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""07e72776-49d3-4be9-ab19-0b69e9f050b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""be812b2b-bbce-463a-ac81-4b792b7825fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchRelease"",
                    ""type"": ""Button"",
                    ""id"": ""fc99cb7a-699b-4eb5-9913-fd5481c60187"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ff44ae7c-8e06-4a81-b8a1-127047cb4981"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TapCount"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1b98003-86b8-441d-abb6-ef4b3fc4a2a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0201f42b-d70f-4487-8ac0-4725f13fb1d7"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a9e804b-a2fc-4958-9433-ace7be6884af"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1e135d5-2536-4202-ae99-6a35152a3680"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc343c1-fa92-435e-bf38-1ff194c68c61"",
                    ""path"": ""<Touchscreen>/touch0/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchStartPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef1d43e6-c61a-4ff6-8e9e-64494da2a44d"",
                    ""path"": ""<Touchscreen>/touch0/tapCount"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapCount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""282a2970-c556-4d27-9122-76d027a138b8"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""f77b6aa7-cf9a-4fca-83b9-6f87d8acf6b1"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_TouchDelta = m_Touch.FindAction("TouchDelta", throwIfNotFound: true);
            m_Touch_TouchStartPosition = m_Touch.FindAction("TouchStartPosition", throwIfNotFound: true);
            m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
            m_Touch_TouchRelease = m_Touch.FindAction("TouchRelease", throwIfNotFound: true);
            m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
            m_Touch_TapCount = m_Touch.FindAction("TapCount", throwIfNotFound: true);
            // Keyboard
            m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_TouchDelta;
        private readonly InputAction m_Touch_TouchStartPosition;
        private readonly InputAction m_Touch_TouchPress;
        private readonly InputAction m_Touch_TouchRelease;
        private readonly InputAction m_Touch_TouchPosition;
        private readonly InputAction m_Touch_TapCount;
        public struct TouchActions
        {
            private @Controls m_Wrapper;
            public TouchActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @TouchDelta => m_Wrapper.m_Touch_TouchDelta;
            public InputAction @TouchStartPosition => m_Wrapper.m_Touch_TouchStartPosition;
            public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
            public InputAction @TouchRelease => m_Wrapper.m_Touch_TouchRelease;
            public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
            public InputAction @TapCount => m_Wrapper.m_Touch_TapCount;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance)
            {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null)
                {
                    @TouchDelta.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDelta;
                    @TouchDelta.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDelta;
                    @TouchDelta.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDelta;
                    @TouchStartPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchStartPosition;
                    @TouchStartPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchStartPosition;
                    @TouchStartPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchStartPosition;
                    @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchRelease.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchRelease;
                    @TouchRelease.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchRelease;
                    @TouchRelease.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchRelease;
                    @TouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TapCount.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapCount;
                    @TapCount.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapCount;
                    @TapCount.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTapCount;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TouchDelta.started += instance.OnTouchDelta;
                    @TouchDelta.performed += instance.OnTouchDelta;
                    @TouchDelta.canceled += instance.OnTouchDelta;
                    @TouchStartPosition.started += instance.OnTouchStartPosition;
                    @TouchStartPosition.performed += instance.OnTouchStartPosition;
                    @TouchStartPosition.canceled += instance.OnTouchStartPosition;
                    @TouchPress.started += instance.OnTouchPress;
                    @TouchPress.performed += instance.OnTouchPress;
                    @TouchPress.canceled += instance.OnTouchPress;
                    @TouchRelease.started += instance.OnTouchRelease;
                    @TouchRelease.performed += instance.OnTouchRelease;
                    @TouchRelease.canceled += instance.OnTouchRelease;
                    @TouchPosition.started += instance.OnTouchPosition;
                    @TouchPosition.performed += instance.OnTouchPosition;
                    @TouchPosition.canceled += instance.OnTouchPosition;
                    @TapCount.started += instance.OnTapCount;
                    @TapCount.performed += instance.OnTapCount;
                    @TapCount.canceled += instance.OnTapCount;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);

        // Keyboard
        private readonly InputActionMap m_Keyboard;
        private IKeyboardActions m_KeyboardActionsCallbackInterface;
        public struct KeyboardActions
        {
            private @Controls m_Wrapper;
            public KeyboardActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
            public void SetCallbacks(IKeyboardActions instance)
            {
                if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
                {
                }
                m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
                if (instance != null)
                {
                }
            }
        }
        public KeyboardActions @Keyboard => new KeyboardActions(this);
        public interface ITouchActions
        {
            void OnTouchDelta(InputAction.CallbackContext context);
            void OnTouchStartPosition(InputAction.CallbackContext context);
            void OnTouchPress(InputAction.CallbackContext context);
            void OnTouchRelease(InputAction.CallbackContext context);
            void OnTouchPosition(InputAction.CallbackContext context);
            void OnTapCount(InputAction.CallbackContext context);
        }
        public interface IKeyboardActions
        {
        }
    }
}
