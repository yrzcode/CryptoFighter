using System;
using UnityEngine;

namespace CryptoFighter.n_Sensor
{
    public class S_BoxEnterExitTriggerSensor : A_TriggerSensor
    {
        private bool _triggerCondition, _preTriggerCondition;

        private void OnTriggerEnter2D(Collider2D col)
        {
            _triggerCondition = !_triggerCondition;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _triggerCondition = !_triggerCondition;
        }

        protected override void Update()
        {
            base.Update();
            _preTriggerCondition = _triggerCondition;

        }

        protected override bool HandleTrigger()
        {
            return _triggerCondition != _preTriggerCondition;
        }
    }
}