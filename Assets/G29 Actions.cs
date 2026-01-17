// GENERATED AUTOMATICALLY FROM 'Assets/G29 Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @G29Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @G29Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""G29 Actions"",
    ""maps"": [
        {
            ""name"": ""Driving"",
            ""id"": ""42da15ca-30ad-4c1a-99ae-22f5fa596bd1"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""64db0761-3d9b-4f6c-9438-d215f6918cc3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""50d32085-4047-412b-b5d1-5f0c5a834b4d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""880ef3f8-9257-4134-87b8-9d5aa0624237"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fd9ec7a-21a7-46d3-9bd7-30a56629989b"",
                    ""path"": ""<HID::Logitech G29 Driving Force Racing Wheel>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""860239d1-4537-47d9-9354-d3055f26ed1f"",
                    ""path"": ""<HID::Logitech G29 Driving Force Racing Wheel>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de35323f-836c-4a94-917e-4fed38ca20a2"",
                    ""path"": ""<HID::Logitech G29 Driving Force Racing Wheel>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Driving
        m_Driving = asset.FindActionMap("Driving", throwIfNotFound: true);
        m_Driving_Throttle = m_Driving.FindAction("Throttle", throwIfNotFound: true);
        m_Driving_Brake = m_Driving.FindAction("Brake", throwIfNotFound: true);
        m_Driving_Steer = m_Driving.FindAction("Steer", throwIfNotFound: true);
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

    // Driving
    private readonly InputActionMap m_Driving;
    private IDrivingActions m_DrivingActionsCallbackInterface;
    private readonly InputAction m_Driving_Throttle;
    private readonly InputAction m_Driving_Brake;
    private readonly InputAction m_Driving_Steer;
    public struct DrivingActions
    {
        private @G29Actions m_Wrapper;
        public DrivingActions(@G29Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_Driving_Throttle;
        public InputAction @Brake => m_Wrapper.m_Driving_Brake;
        public InputAction @Steer => m_Wrapper.m_Driving_Steer;
        public InputActionMap Get() { return m_Wrapper.m_Driving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DrivingActions set) { return set.Get(); }
        public void SetCallbacks(IDrivingActions instance)
        {
            if (m_Wrapper.m_DrivingActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrake;
                @Steer.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteer;
            }
            m_Wrapper.m_DrivingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
            }
        }
    }
    public DrivingActions @Driving => new DrivingActions(this);
    public interface IDrivingActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
    }
}
