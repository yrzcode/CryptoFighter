using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class S_TopBouncy : MonoBehaviour
    {
        [SerializeField] private float _bouncyForce;
        [SerializeField] private List<GameObject> _triggerList;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_triggerList != null)
                foreach (var trigger in _triggerList)
                {
                    if (other.gameObject.CompareTag(trigger.tag))
                    {
                        var  rb2D = other.GetComponent<Rigidbody2D>();
                        if (rb2D != null) rb2D.velocity += Vector2.down * _bouncyForce;
                    }
                }
        }
    }
}

