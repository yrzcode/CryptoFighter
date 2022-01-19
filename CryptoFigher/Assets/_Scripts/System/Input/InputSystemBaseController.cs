
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CryptoFighter.n_InputSystem
{
    public class InputSystemBaseController : MonoBehaviour,IInputSystemController
    {


        private PlayerAction _inputActions;
        
        public Action<InputAction.CallbackContext> JumpAction { get; set; }

        public PlayerAction GetInputAction() => _inputActions;
        

        void Awake()
        {
            _inputActions = new PlayerAction();
            _inputActions.Enable();
        }


        private void Start()
        {
            _inputActions.Player.Jump.performed += JumpAction;
        }


        private void OnDisable()
        {
            _inputActions.Player.Jump.performed -= JumpAction;
        }


    }


}
