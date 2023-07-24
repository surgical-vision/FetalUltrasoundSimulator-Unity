// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay_3dmouse"",
            ""id"": ""91353f47-c2f8-46d8-b3f3-e7c6c906bd19"",
            ""actions"": [
                {
                    ""name"": ""ResetPlane"",
                    ""type"": ""Button"",
                    ""id"": ""0afdfbeb-ce0c-448b-abfb-49d85472858d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""9a9a41b4-34b7-4c0e-b83d-2d520738139f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""628f7c09-7789-4c46-923a-aa2c4a1acab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeMaterial"",
                    ""type"": ""Button"",
                    ""id"": ""d677e024-302b-4b94-8303-86cb68806e1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranslationOnly"",
                    ""type"": ""Button"",
                    ""id"": ""f0d8a5ee-10fa-47a2-bba9-4643953b7275"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationOnly"",
                    ""type"": ""Button"",
                    ""id"": ""6ba94b3b-9b74-4525-9952-a77d9c1a69bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1dc00ed3-8420-4151-891b-bdcdc5f40b90"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/button13"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetPlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a39f9362-6daf-4e46-b749-91f74066b280"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/button14"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMaterial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f957bde-ef4b-4fd9-887d-2176fd36e6e0"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/button15"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TranslationOnly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f93028a-78ba-4def-9171-49210d26b628"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/button16"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationOnly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbaee6f2-43e6-41a5-93a4-fa1edd33f852"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5ff79a3-1812-44c4-9c7f-d5ed30c3d675"",
                    ""path"": ""<HID::3Dconnexion SpaceMouse Pro MultiAxisController>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay_joystick"",
            ""id"": ""5e94fd2a-9b58-4b45-bdaf-afe35a159993"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b1facdcc-c9e6-454c-b440-512e0bdc3040"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""ddcb5f08-f6bb-4d0d-b3dc-26abae543900"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VertMov"",
                    ""type"": ""Value"",
                    ""id"": ""2fdfd377-c3b8-49b0-a89b-92a13d53d15f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetPlane"",
                    ""type"": ""Button"",
                    ""id"": ""523b7229-bd00-47fc-ace4-f187e4fd9dd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeMaterial"",
                    ""type"": ""Button"",
                    ""id"": ""e1f916e9-e9f8-4ca8-9ef8-56245d2f218e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TakeScreenshot"",
                    ""type"": ""Button"",
                    ""id"": ""570efc5e-c10d-4f9d-8b7a-bbfa1ed00934"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlideProbe"",
                    ""type"": ""Button"",
                    ""id"": ""98f5ee3e-3baf-47f9-a4cf-82761a03ecda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ee788d5d-95c3-4b14-9898-6d69d2b75177"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c433e418-c7f5-4470-9d6b-91ea9d5ca014"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1e3922a-da31-4c66-aa20-2068dad38ed9"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VertMov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae1a5ccc-4de2-41f4-9872-f31da63a1088"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetPlane"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c8104df-ef15-4737-9b70-85804d94337f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMaterial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""879906af-9d97-48c2-9b8b-529e5bf827ee"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TakeScreenshot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b197ac8f-4694-42a6-9a4c-88d0b34e5f34"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlideProbe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay_3dmouse
        m_Gameplay_3dmouse = asset.FindActionMap("Gameplay_3dmouse", throwIfNotFound: true);
        m_Gameplay_3dmouse_ResetPlane = m_Gameplay_3dmouse.FindAction("ResetPlane", throwIfNotFound: true);
        m_Gameplay_3dmouse_Rotate = m_Gameplay_3dmouse.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_3dmouse_Move = m_Gameplay_3dmouse.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_3dmouse_ChangeMaterial = m_Gameplay_3dmouse.FindAction("ChangeMaterial", throwIfNotFound: true);
        m_Gameplay_3dmouse_TranslationOnly = m_Gameplay_3dmouse.FindAction("TranslationOnly", throwIfNotFound: true);
        m_Gameplay_3dmouse_RotationOnly = m_Gameplay_3dmouse.FindAction("RotationOnly", throwIfNotFound: true);
        // Gameplay_joystick
        m_Gameplay_joystick = asset.FindActionMap("Gameplay_joystick", throwIfNotFound: true);
        m_Gameplay_joystick_Move = m_Gameplay_joystick.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_joystick_Rotate = m_Gameplay_joystick.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_joystick_VertMov = m_Gameplay_joystick.FindAction("VertMov", throwIfNotFound: true);
        m_Gameplay_joystick_ResetPlane = m_Gameplay_joystick.FindAction("ResetPlane", throwIfNotFound: true);
        m_Gameplay_joystick_ChangeMaterial = m_Gameplay_joystick.FindAction("ChangeMaterial", throwIfNotFound: true);
        m_Gameplay_joystick_TakeScreenshot = m_Gameplay_joystick.FindAction("TakeScreenshot", throwIfNotFound: true);
        m_Gameplay_joystick_SlideProbe = m_Gameplay_joystick.FindAction("SlideProbe", throwIfNotFound: true);
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

    // Gameplay_3dmouse
    private readonly InputActionMap m_Gameplay_3dmouse;
    private IGameplay_3dmouseActions m_Gameplay_3dmouseActionsCallbackInterface;
    private readonly InputAction m_Gameplay_3dmouse_ResetPlane;
    private readonly InputAction m_Gameplay_3dmouse_Rotate;
    private readonly InputAction m_Gameplay_3dmouse_Move;
    private readonly InputAction m_Gameplay_3dmouse_ChangeMaterial;
    private readonly InputAction m_Gameplay_3dmouse_TranslationOnly;
    private readonly InputAction m_Gameplay_3dmouse_RotationOnly;
    public struct Gameplay_3dmouseActions
    {
        private @PlayerControls m_Wrapper;
        public Gameplay_3dmouseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetPlane => m_Wrapper.m_Gameplay_3dmouse_ResetPlane;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_3dmouse_Rotate;
        public InputAction @Move => m_Wrapper.m_Gameplay_3dmouse_Move;
        public InputAction @ChangeMaterial => m_Wrapper.m_Gameplay_3dmouse_ChangeMaterial;
        public InputAction @TranslationOnly => m_Wrapper.m_Gameplay_3dmouse_TranslationOnly;
        public InputAction @RotationOnly => m_Wrapper.m_Gameplay_3dmouse_RotationOnly;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay_3dmouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay_3dmouseActions set) { return set.Get(); }
        public void SetCallbacks(IGameplay_3dmouseActions instance)
        {
            if (m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface != null)
            {
                @ResetPlane.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnResetPlane;
                @ResetPlane.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnResetPlane;
                @ResetPlane.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnResetPlane;
                @Rotate.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotate;
                @Move.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnMove;
                @ChangeMaterial.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnChangeMaterial;
                @ChangeMaterial.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnChangeMaterial;
                @ChangeMaterial.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnChangeMaterial;
                @TranslationOnly.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnTranslationOnly;
                @TranslationOnly.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnTranslationOnly;
                @TranslationOnly.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnTranslationOnly;
                @RotationOnly.started -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotationOnly;
                @RotationOnly.performed -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotationOnly;
                @RotationOnly.canceled -= m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface.OnRotationOnly;
            }
            m_Wrapper.m_Gameplay_3dmouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResetPlane.started += instance.OnResetPlane;
                @ResetPlane.performed += instance.OnResetPlane;
                @ResetPlane.canceled += instance.OnResetPlane;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ChangeMaterial.started += instance.OnChangeMaterial;
                @ChangeMaterial.performed += instance.OnChangeMaterial;
                @ChangeMaterial.canceled += instance.OnChangeMaterial;
                @TranslationOnly.started += instance.OnTranslationOnly;
                @TranslationOnly.performed += instance.OnTranslationOnly;
                @TranslationOnly.canceled += instance.OnTranslationOnly;
                @RotationOnly.started += instance.OnRotationOnly;
                @RotationOnly.performed += instance.OnRotationOnly;
                @RotationOnly.canceled += instance.OnRotationOnly;
            }
        }
    }
    public Gameplay_3dmouseActions @Gameplay_3dmouse => new Gameplay_3dmouseActions(this);

    // Gameplay_joystick
    private readonly InputActionMap m_Gameplay_joystick;
    private IGameplay_joystickActions m_Gameplay_joystickActionsCallbackInterface;
    private readonly InputAction m_Gameplay_joystick_Move;
    private readonly InputAction m_Gameplay_joystick_Rotate;
    private readonly InputAction m_Gameplay_joystick_VertMov;
    private readonly InputAction m_Gameplay_joystick_ResetPlane;
    private readonly InputAction m_Gameplay_joystick_ChangeMaterial;
    private readonly InputAction m_Gameplay_joystick_TakeScreenshot;
    private readonly InputAction m_Gameplay_joystick_SlideProbe;
    public struct Gameplay_joystickActions
    {
        private @PlayerControls m_Wrapper;
        public Gameplay_joystickActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_joystick_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_joystick_Rotate;
        public InputAction @VertMov => m_Wrapper.m_Gameplay_joystick_VertMov;
        public InputAction @ResetPlane => m_Wrapper.m_Gameplay_joystick_ResetPlane;
        public InputAction @ChangeMaterial => m_Wrapper.m_Gameplay_joystick_ChangeMaterial;
        public InputAction @TakeScreenshot => m_Wrapper.m_Gameplay_joystick_TakeScreenshot;
        public InputAction @SlideProbe => m_Wrapper.m_Gameplay_joystick_SlideProbe;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay_joystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay_joystickActions set) { return set.Get(); }
        public void SetCallbacks(IGameplay_joystickActions instance)
        {
            if (m_Wrapper.m_Gameplay_joystickActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnRotate;
                @VertMov.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnVertMov;
                @VertMov.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnVertMov;
                @VertMov.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnVertMov;
                @ResetPlane.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnResetPlane;
                @ResetPlane.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnResetPlane;
                @ResetPlane.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnResetPlane;
                @ChangeMaterial.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnChangeMaterial;
                @ChangeMaterial.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnChangeMaterial;
                @ChangeMaterial.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnChangeMaterial;
                @TakeScreenshot.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnTakeScreenshot;
                @TakeScreenshot.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnTakeScreenshot;
                @TakeScreenshot.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnTakeScreenshot;
                @SlideProbe.started -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnSlideProbe;
                @SlideProbe.performed -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnSlideProbe;
                @SlideProbe.canceled -= m_Wrapper.m_Gameplay_joystickActionsCallbackInterface.OnSlideProbe;
            }
            m_Wrapper.m_Gameplay_joystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @VertMov.started += instance.OnVertMov;
                @VertMov.performed += instance.OnVertMov;
                @VertMov.canceled += instance.OnVertMov;
                @ResetPlane.started += instance.OnResetPlane;
                @ResetPlane.performed += instance.OnResetPlane;
                @ResetPlane.canceled += instance.OnResetPlane;
                @ChangeMaterial.started += instance.OnChangeMaterial;
                @ChangeMaterial.performed += instance.OnChangeMaterial;
                @ChangeMaterial.canceled += instance.OnChangeMaterial;
                @TakeScreenshot.started += instance.OnTakeScreenshot;
                @TakeScreenshot.performed += instance.OnTakeScreenshot;
                @TakeScreenshot.canceled += instance.OnTakeScreenshot;
                @SlideProbe.started += instance.OnSlideProbe;
                @SlideProbe.performed += instance.OnSlideProbe;
                @SlideProbe.canceled += instance.OnSlideProbe;
            }
        }
    }
    public Gameplay_joystickActions @Gameplay_joystick => new Gameplay_joystickActions(this);
    public interface IGameplay_3dmouseActions
    {
        void OnResetPlane(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnChangeMaterial(InputAction.CallbackContext context);
        void OnTranslationOnly(InputAction.CallbackContext context);
        void OnRotationOnly(InputAction.CallbackContext context);
    }
    public interface IGameplay_joystickActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnVertMov(InputAction.CallbackContext context);
        void OnResetPlane(InputAction.CallbackContext context);
        void OnChangeMaterial(InputAction.CallbackContext context);
        void OnTakeScreenshot(InputAction.CallbackContext context);
        void OnSlideProbe(InputAction.CallbackContext context);
    }
}
