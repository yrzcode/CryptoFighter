using System.Collections.Generic;
using CryptoFighter.n_Status;
using UnityEngine;

namespace System.Movement.S_Accelerate
{
    public class S_TriggerEnterAccelerate : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _triggerItems;
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private float _accelerateAmount;

        private void OnTriggerEnter2D(Collider2D col)
        {
            foreach (var triggerItem in _triggerItems)
            {
                if (col.gameObject.CompareTag(triggerItem.tag)) _moveSpeed.CurrentMoveSpeed += _accelerateAmount;
            }
        }
    }
}