//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls/MoskitoControls.inputactions
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

public partial class @MoskitoControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MoskitoControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MoskitoControls"",
    ""maps"": [
        {
            ""name"": ""Moskito"",
            ""id"": ""948b7788-c8d6-4d55-8504-5450826f5461"",
            ""actions"": [
                {
                    ""name"": ""Fly"",
                    ""type"": ""Button"",
                    ""id"": ""e0c00214-9f2d-4037-bcd8-7d6192744129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""33f79e66-6d9e-4ae2-948f-5f214bdee676"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""c0a950ee-af91-409a-9929-c4d9c6ebc6d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sting"",
                    ""type"": ""Button"",
                    ""id"": ""6210c147-0722-4074-a528-9a76cfee8bf6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""791d5edd-8576-431d-b151-15ad686f00a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf4a2e36-0803-461f-9b9d-9fb77100820f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae000121-ab1f-478f-930c-1631020ac5a9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""36e3af98-af10-4d59-848b-86c7978b048f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""339b8c52-78d6-4b36-832c-e888c900ac75"",
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
                    ""id"": ""501b9b7e-6187-444a-815b-09c9163d6240"",
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
                    ""id"": ""8753dc82-8435-4bc8-a7d4-9a8222b4224e"",
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
                    ""id"": ""1b2723d6-6d6b-4b96-8b16-9c1f824cd972"",
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
                    ""id"": ""72cf4b4a-3587-4e69-affd-3443ffc6b598"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d54dcf75-b954-423d-84ea-1c844079f664"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33246fb4-2ed2-4b67-8bd5-0232819f6378"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16aa52f5-953e-4ba1-9080-ef204178d078"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Human"",
            ""id"": ""517c74ba-b80b-455a-ab12-e2e3e52fc614"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""7ca55fbd-8383-463b-8c7d-3f5284af3dd0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""e3107169-abc5-4ab2-ad2f-0ffd2f92d23d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""173e80f8-80d0-4973-915e-66189ca04b5e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7d509f7e-7141-4c35-a2b3-d328e06e1378"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d9dfa0de-a5e9-4d18-bc65-ad7f8b845aa6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""331a467b-4cb3-4974-a1cc-87d80811be9b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f034372b-a517-478f-967d-d9e84fc370c3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6e10d61-40c6-403d-a973-0d60402d58b4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19b90b74-f33a-40de-a911-48b7687368fd"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba2298e3-96ee-4570-b773-cf76d3d6357f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""UniversalControlScheme"",
            ""bindingGroup"": ""UniversalControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Moskito
        m_Moskito = asset.FindActionMap("Moskito", throwIfNotFound: true);
        m_Moskito_Fly = m_Moskito.FindAction("Fly", throwIfNotFound: true);
        m_Moskito_Move = m_Moskito.FindAction("Move", throwIfNotFound: true);
        m_Moskito_Camera = m_Moskito.FindAction("Camera", throwIfNotFound: true);
        m_Moskito_Sting = m_Moskito.FindAction("Sting", throwIfNotFound: true);
        // Human
        m_Human = asset.FindActionMap("Human", throwIfNotFound: true);
        m_Human_Walk = m_Human.FindAction("Walk", throwIfNotFound: true);
        m_Human_Camera = m_Human.FindAction("Camera", throwIfNotFound: true);
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

    // Moskito
    private readonly InputActionMap m_Moskito;
    private List<IMoskitoActions> m_MoskitoActionsCallbackInterfaces = new List<IMoskitoActions>();
    private readonly InputAction m_Moskito_Fly;
    private readonly InputAction m_Moskito_Move;
    private readonly InputAction m_Moskito_Camera;
    private readonly InputAction m_Moskito_Sting;
    public struct MoskitoActions
    {
        private @MoskitoControls m_Wrapper;
        public MoskitoActions(@MoskitoControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fly => m_Wrapper.m_Moskito_Fly;
        public InputAction @Move => m_Wrapper.m_Moskito_Move;
        public InputAction @Camera => m_Wrapper.m_Moskito_Camera;
        public InputAction @Sting => m_Wrapper.m_Moskito_Sting;
        public InputActionMap Get() { return m_Wrapper.m_Moskito; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoskitoActions set) { return set.Get(); }
        public void AddCallbacks(IMoskitoActions instance)
        {
            if (instance == null || m_Wrapper.m_MoskitoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoskitoActionsCallbackInterfaces.Add(instance);
            @Fly.started += instance.OnFly;
            @Fly.performed += instance.OnFly;
            @Fly.canceled += instance.OnFly;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
            @Sting.started += instance.OnSting;
            @Sting.performed += instance.OnSting;
            @Sting.canceled += instance.OnSting;
        }

        private void UnregisterCallbacks(IMoskitoActions instance)
        {
            @Fly.started -= instance.OnFly;
            @Fly.performed -= instance.OnFly;
            @Fly.canceled -= instance.OnFly;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
            @Sting.started -= instance.OnSting;
            @Sting.performed -= instance.OnSting;
            @Sting.canceled -= instance.OnSting;
        }

        public void RemoveCallbacks(IMoskitoActions instance)
        {
            if (m_Wrapper.m_MoskitoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoskitoActions instance)
        {
            foreach (var item in m_Wrapper.m_MoskitoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoskitoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoskitoActions @Moskito => new MoskitoActions(this);

    // Human
    private readonly InputActionMap m_Human;
    private List<IHumanActions> m_HumanActionsCallbackInterfaces = new List<IHumanActions>();
    private readonly InputAction m_Human_Walk;
    private readonly InputAction m_Human_Camera;
    public struct HumanActions
    {
        private @MoskitoControls m_Wrapper;
        public HumanActions(@MoskitoControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Human_Walk;
        public InputAction @Camera => m_Wrapper.m_Human_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Human; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanActions set) { return set.Get(); }
        public void AddCallbacks(IHumanActions instance)
        {
            if (instance == null || m_Wrapper.m_HumanActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HumanActionsCallbackInterfaces.Add(instance);
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
        }

        private void UnregisterCallbacks(IHumanActions instance)
        {
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
        }

        public void RemoveCallbacks(IHumanActions instance)
        {
            if (m_Wrapper.m_HumanActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHumanActions instance)
        {
            foreach (var item in m_Wrapper.m_HumanActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HumanActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HumanActions @Human => new HumanActions(this);
    private int m_UniversalControlSchemeSchemeIndex = -1;
    public InputControlScheme UniversalControlSchemeScheme
    {
        get
        {
            if (m_UniversalControlSchemeSchemeIndex == -1) m_UniversalControlSchemeSchemeIndex = asset.FindControlSchemeIndex("UniversalControlScheme");
            return asset.controlSchemes[m_UniversalControlSchemeSchemeIndex];
        }
    }
    public interface IMoskitoActions
    {
        void OnFly(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnSting(InputAction.CallbackContext context);
    }
    public interface IHumanActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
}
