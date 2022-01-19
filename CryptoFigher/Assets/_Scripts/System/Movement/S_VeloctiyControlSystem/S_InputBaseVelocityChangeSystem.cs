using System;
using UnityEngine;
using UnityEngine.InputSystem;
using CryptoFighter.n_Status;
using CryptoFighter.n_InputSystem;

namespace CryptoFighter.n_Movement
{

    public class S_InputBaseVelocityChangeSystem : VeloctiyChangeSystem,IOnVelocityChangeAction,IPlayFeedbackAction
    {
        [SerializeField] InputSystemBaseController _input;

        [SerializeField] Rigidbody2D _rigidbody2D;

        [SerializeField] Force _forceX;
        [SerializeField] Force _forceY;


        float velocityX;
        float velocityY;

        public event Action OnInputBaseVelocityChange;
        public event Action OnVelocityChangeAction;
        public event Action OnPlayFeedbackAction;

        private void OnEnable()
        {
            _input.JumpAction += ChangeVelocity;
            SubOnVelocityChangeAction();
        }

        private void OnDisable()
        {
            _input.JumpAction -= ChangeVelocity;
            UnsubOnVelocityChangeAction();
        }


        public override void ChangeVelocity()
        {
    
            _rigidbody2D.velocity = Vector2.zero;
            OnVelocityChangeAction?.Invoke();

        }
        
        public void ChangeVelocity(InputAction.CallbackContext context)
        {

            if (_forceX != null) velocityX = _forceX.GetCurrentForce();
            if (_forceY != null) velocityY = _forceY.GetCurrentForce();
            _rigidbody2D.velocity += new Vector2(velocityX, velocityY);

            OnInputBaseVelocityChange?.Invoke();
            OnVelocityChangeAction?.Invoke();

        }

        public void SubOnVelocityChangeAction()
        {
            OnVelocityChangeAction = OnPlayFeedbackAction;
        }

        public void UnsubOnVelocityChangeAction()
        {
            OnVelocityChangeAction = null;
        }

    }

}
