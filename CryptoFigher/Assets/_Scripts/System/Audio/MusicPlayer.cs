using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Audio
{

    public class MusicPlayer : MonoBehaviour
    {

        [SerializeField] AudioSource _musicPlayer;


        public void PlayMusic(AudioClip music)
        {
            _musicPlayer.clip = music;
            _musicPlayer.Play();
        }

        public void StopMusic()
        {
            _musicPlayer.Stop();
        }

    }
}


