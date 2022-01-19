using Sirenix.OdinInspector;
using UnityEngine;

namespace CryptoFighter.n_Sensor
{
    public abstract class A_TriggerSensor : MonoBehaviour
    {
        [SerializeField][ReadOnly]
        private bool _isTrigger;
        public bool IsTrigger
        {
            get => _isTrigger;
            private set => _isTrigger = value;
        }

        protected virtual void Update()
        {
            IsTrigger = HandleTrigger();
        }

        protected abstract bool HandleTrigger();
    }
}