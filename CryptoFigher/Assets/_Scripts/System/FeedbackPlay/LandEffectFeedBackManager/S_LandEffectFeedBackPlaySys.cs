using CryptoFighter.n_Sensor;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace System.FeedbackPlay.LandEffectFeedBackManager
{
    public class S_LandEffectFeedBackPlaySys: MonoBehaviour
    {
        [SerializeField] private MMFeedbacks _feedbackEffect;
        [SerializeField] private A_TriggerSensor _triggerSensor;

        private void Update()
        {
            if (_triggerSensor.IsTrigger) _feedbackEffect.PlayFeedbacks();
        }
    }
}