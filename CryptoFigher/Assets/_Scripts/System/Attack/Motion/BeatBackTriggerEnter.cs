using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace CryptoFighter.n_Movement
{
    public class BeatBackTriggerEnter : SerializedMonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Vector2 _beatBackDirection;
        [SerializeField] private float _beatBackTime;
        [SerializeField] private Dictionary<GameObject, float> _beatBackForceDic;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_beatBackForceDic != null)  
                foreach (var dic in _beatBackForceDic)
                {
                    if (other.gameObject.CompareTag(dic.Key.tag))
                    {
                        var positionOther = other.transform.position;
                        var position = gameObject.transform.position;
                        var forceDirectionX = position.x - positionOther.x; 
                        var forceDirectionY = position.y - positionOther.y;
                        var forceDirection = new Vector2(forceDirectionX,forceDirectionY);
                        
                        StartCoroutine(Co_BeatBack(forceDirection , dic.Value));
                    }
                }
        }

        private IEnumerator Co_BeatBack(Vector2 forceDirection, float beatBackForce)
        {
            for (float i = _beatBackTime; i > 0; i -= Time.deltaTime)
            {
                var velocityX = _beatBackDirection.normalized.x * forceDirection.x * beatBackForce * i;
                _rigidbody2D.velocity = new Vector2(velocityX, _rigidbody2D.velocity.y);
                yield return null;
            }
        }
    }
}



