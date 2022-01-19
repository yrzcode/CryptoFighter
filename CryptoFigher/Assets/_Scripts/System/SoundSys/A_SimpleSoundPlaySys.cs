
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Sound
{
    public abstract class A_SimpleSoundPlaySys : MonoBehaviour
    {
        [SerializeField] protected bool _shouldPlaySound;
        [SerializeField] protected List<AudioSource> _audioSources;
        public abstract void HandlePlaySound();
    }
}

