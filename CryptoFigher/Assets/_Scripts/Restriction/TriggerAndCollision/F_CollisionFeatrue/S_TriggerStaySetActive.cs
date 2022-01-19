using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class S_TriggerStaySetActive : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private List<string> _triggerTagsList;

        private void OnTriggerStay2D(Collider2D other)
        {
            foreach (var triggerTag in _triggerTagsList)
            {
                if (other.gameObject.CompareTag(triggerTag))
                {
                    _gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
            foreach (var triggerTag in _triggerTagsList)
            {
                if (other.gameObject.CompareTag(triggerTag))
                {
                    _gameObject.SetActive(false);
                }
            }
        }
        
    }
}