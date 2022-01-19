using System.Collections.Generic;
using UnityEngine;

namespace System.ScaleControl
{
    public class S_TriggerEnterChangeScale : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Vector3 _endScale;
        [SerializeField] private List<GameObject> _triggerObjects;

        private void ChangeScaleTo(Vector3 scale)
        {
            if (_gameObject != null) _gameObject.transform.localScale = scale;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_triggerObjects != null)
                foreach (var triggerObject in _triggerObjects)
                {
                    if (other.gameObject.CompareTag(triggerObject.tag))
                    {
                        ChangeScaleTo(_endScale);
                    }
                }
        }
    }
}