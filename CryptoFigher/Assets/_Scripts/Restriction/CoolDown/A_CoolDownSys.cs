using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public abstract class A_CoolDownSys : MonoBehaviour
    {
        [SerializeField] protected float _durationTime;
        [SerializeField] protected float _recoverTime;
        private bool _isCoolDown;
        private float _recoverTimer;
        private float _durationTimer;

        public bool IsCoolDown => _isCoolDown;

        protected float DurationTimer
        {
            get => _durationTimer;
            set => _durationTimer = Mathf.Clamp(value, 0,float.MaxValue) ;
        }

        protected virtual void Update()
        {
            if (_durationTimer > _durationTime)
            {
                _isCoolDown = true;
            }
            
            if (_isCoolDown)
            {
                _recoverTimer += Time.deltaTime;
                if (_recoverTimer > _recoverTime)
                {
                    _isCoolDown = false;
                    _durationTimer = 0;
                    _recoverTimer = 0;
                }
            }
        }
    }
}