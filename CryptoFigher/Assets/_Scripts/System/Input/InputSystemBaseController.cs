using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_InputSystem
{

    public class InputSystemBaseController : MonoBehaviour, IInputController
    {

        private PlayerAction inputActions;

        public PlayerAction InputActions { get => inputActions; set => inputActions = value; }

        public PlayerAction GetInputAction() => InputActions;


        void Awake()
        {
            InputActions = new PlayerAction();
            InputActions.Enable();
        }


    }


}
