//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/GameInput.inputactions
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

public partial class @GameInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""1b103484-ab29-4ae4-9131-ed48689f3a43"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""75f2f531-7f63-401c-a135-9babfcdd900c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""4a288123-8445-47c2-ac2f-a5de8f0a4eac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""6d2e9756-c5c0-49bd-8805-138977bdfb30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Thruster"",
                    ""type"": ""Button"",
                    ""id"": ""a581ceef-b7e7-43fa-a96f-11238d414e46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuitButton"",
                    ""type"": ""Button"",
                    ""id"": ""eb2e08d2-b747-42df-bbe1-5368bc8575b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ContinueDialog"",
                    ""type"": ""Button"",
                    ""id"": ""5c1553fb-4b3d-4d1b-aabd-06adfdc975c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gravity Pull"",
                    ""type"": ""Button"",
                    ""id"": ""df301a37-21ba-4789-8137-5eb88ea8d674"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HomingMissle"",
                    ""type"": ""Button"",
                    ""id"": ""47c88e5d-80bf-4781-a0dc-4d38aef7a7a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""33668f41-ac56-4133-9bd0-b223ce2cd609"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""da4d44eb-a52c-4e0d-9418-d6925bdac39a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d0ff95c5-ad18-4d01-a752-8e6ef2ff42d6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7d63dc58-5f19-4707-b501-654dc1ca5573"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""53471022-4dd5-46e2-ba05-0274bcb9ee4e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c58ceb6-9bbd-46f2-a732-6c8f15f5859b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""6904da2c-c08f-46f5-8af6-3d52a95b13f2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""23facd96-d97f-49cb-b44d-f45a24af463d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2309a15e-7281-41c4-a750-9ac1f7da3049"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""faef6931-556f-4068-aabf-d4f6ed065efc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""13184ea4-9651-4d7d-a5c9-683cb4355dbc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""be36c4d7-0cb6-46ec-a310-3c4cbb8b0050"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c4ffe03-b8c6-462a-99b3-a8ec939dc885"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""329886da-bc83-477f-a319-4e5c8a42bc67"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1e71b7d-6a3e-47fb-b378-08a3dd870568"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""199a0e10-a5d9-43cc-9bf8-3d7161e91757"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2be0ae8d-23e6-4882-8b9b-f83ec88dd032"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thruster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4391aceb-6c47-4f02-9df7-20450efa18ac"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2fd6aa9-32ed-4709-be9f-a619d5801709"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5985d5b1-2dd7-478f-81de-19326496299f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb15392-546d-40db-8b33-359fb2f06fe4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ContinueDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""758cd9e4-7ad3-4bc5-9983-3e503afb37ee"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gravity Pull"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86f3c5aa-41c2-4355-8a9f-59ff2d1f8cef"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gravity Pull"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49506e08-da7c-4ba8-9df0-0e541d9baa82"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingMissle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c9011af-77a6-4b31-8d36-6db0f5cf67f3"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HomingMissle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Fire = m_PlayerControls.FindAction("Fire", throwIfNotFound: true);
        m_PlayerControls_Restart = m_PlayerControls.FindAction("Restart", throwIfNotFound: true);
        m_PlayerControls_Thruster = m_PlayerControls.FindAction("Thruster", throwIfNotFound: true);
        m_PlayerControls_QuitButton = m_PlayerControls.FindAction("QuitButton", throwIfNotFound: true);
        m_PlayerControls_ContinueDialog = m_PlayerControls.FindAction("ContinueDialog", throwIfNotFound: true);
        m_PlayerControls_GravityPull = m_PlayerControls.FindAction("Gravity Pull", throwIfNotFound: true);
        m_PlayerControls_HomingMissle = m_PlayerControls.FindAction("HomingMissle", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Fire;
    private readonly InputAction m_PlayerControls_Restart;
    private readonly InputAction m_PlayerControls_Thruster;
    private readonly InputAction m_PlayerControls_QuitButton;
    private readonly InputAction m_PlayerControls_ContinueDialog;
    private readonly InputAction m_PlayerControls_GravityPull;
    private readonly InputAction m_PlayerControls_HomingMissle;
    public struct PlayerControlsActions
    {
        private @GameInput m_Wrapper;
        public PlayerControlsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Fire => m_Wrapper.m_PlayerControls_Fire;
        public InputAction @Restart => m_Wrapper.m_PlayerControls_Restart;
        public InputAction @Thruster => m_Wrapper.m_PlayerControls_Thruster;
        public InputAction @QuitButton => m_Wrapper.m_PlayerControls_QuitButton;
        public InputAction @ContinueDialog => m_Wrapper.m_PlayerControls_ContinueDialog;
        public InputAction @GravityPull => m_Wrapper.m_PlayerControls_GravityPull;
        public InputAction @HomingMissle => m_Wrapper.m_PlayerControls_HomingMissle;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFire;
                @Restart.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRestart;
                @Thruster.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThruster;
                @Thruster.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThruster;
                @Thruster.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnThruster;
                @QuitButton.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuitButton;
                @QuitButton.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuitButton;
                @QuitButton.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnQuitButton;
                @ContinueDialog.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnContinueDialog;
                @ContinueDialog.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnContinueDialog;
                @GravityPull.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGravityPull;
                @GravityPull.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGravityPull;
                @GravityPull.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGravityPull;
                @HomingMissle.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHomingMissle;
                @HomingMissle.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHomingMissle;
                @HomingMissle.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHomingMissle;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Thruster.started += instance.OnThruster;
                @Thruster.performed += instance.OnThruster;
                @Thruster.canceled += instance.OnThruster;
                @QuitButton.started += instance.OnQuitButton;
                @QuitButton.performed += instance.OnQuitButton;
                @QuitButton.canceled += instance.OnQuitButton;
                @ContinueDialog.started += instance.OnContinueDialog;
                @ContinueDialog.performed += instance.OnContinueDialog;
                @ContinueDialog.canceled += instance.OnContinueDialog;
                @GravityPull.started += instance.OnGravityPull;
                @GravityPull.performed += instance.OnGravityPull;
                @GravityPull.canceled += instance.OnGravityPull;
                @HomingMissle.started += instance.OnHomingMissle;
                @HomingMissle.performed += instance.OnHomingMissle;
                @HomingMissle.canceled += instance.OnHomingMissle;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnThruster(InputAction.CallbackContext context);
        void OnQuitButton(InputAction.CallbackContext context);
        void OnContinueDialog(InputAction.CallbackContext context);
        void OnGravityPull(InputAction.CallbackContext context);
        void OnHomingMissle(InputAction.CallbackContext context);
    }
}
