using System;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Attack.n_Damage
{
    public class S_TriggerChangeColor : MonoBehaviour
    {
        [SerializeField] private List<string> _tags;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _color;
        private void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var tag in _tags)
            {
                if (!other.gameObject.CompareTag(tag)) return;
                _renderer.material.color = _color;
            }
        }
    }
}