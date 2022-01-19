using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Destroy
{
    public class S_TriggerDestroy : MonoBehaviour
    {
        private enum Mode
        {
            DestroySelf,
            DestroyOther
        }

        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Mode _destroyMode;
        [SerializeField] private List<GameObject> _triggerList;
        [SerializeField] private GameObject _destroyEffect;

        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var trigger in _triggerList)
            {
                if (other.gameObject.CompareTag(trigger.tag))
                {
                    switch (_destroyMode)
                    {
                        case Mode.DestroySelf:
                            Destroy(_gameObject);
                            break;
                        case Mode.DestroyOther:
                            Destroy(other.gameObject);
                            break;
                    }
                }
                
                Functions.PlayEffect(_destroyEffect,transform.position,1f);
            }
        }
    }
    
}