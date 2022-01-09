using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

namespace CryptoFighter.n_InputSystem
{

    public class InputSystemBaseController : MonoBehaviour,IInputSystemController
    {


        private PlayerAction _inputActions;
        private Action<InputAction.CallbackContext> jumpAction;
        

        public Action<InputAction.CallbackContext> JumpAction { get => jumpAction; set => jumpAction = value; }

        public PlayerAction GetInputAction() => _inputActions;
        

        void Awake()
        {
            _inputActions = new PlayerAction();
            _inputActions.Enable();

        }


        private void OnEnable()
        {
            _inputActions.Player.Jump.performed += JumpAction;

        }

        private void OnDisable()
        {
            _inputActions.Player.Jump.performed -= JumpAction;
        }


    }


}
