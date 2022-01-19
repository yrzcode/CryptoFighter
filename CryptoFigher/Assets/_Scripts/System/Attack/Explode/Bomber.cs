using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_Attack.Explode
{
    public class Bomber : MonoBehaviour, _IBomber
    {
        [SerializeField] SpriteRenderer _spriteRender;
        [SerializeField] MoveSpeed _moveSpeed;
        [SerializeField] float _bombCountDownTime;

        [SerializeField] List<GameObject> _damageTargets;

        [SerializeField] AudioClip _explosionSound;
        [SerializeField] GameObject _explosionEffectPrefab;

        private IEnumerator Flashing()
        {

            while (true)
            {
                _spriteRender.color = new Color32(255, 0, 0, 150);

                yield return new WaitForSeconds(0.3f);

                _spriteRender.color = new Color32(255, 0, 0, 255);

                yield return new WaitForSeconds(0.3f);

            }

        }

        private IEnumerator Explosion()
        {

            yield return new WaitForSeconds(_bombCountDownTime);

            Explpode();
        }

        public void Explpode()
        {
            PlayBombExplosionEffect();
            PlayBombExplosionSound();
            Destroy(gameObject);
        }

        private void PlayBombExplosionSound()
        {
            if (_explosionSound != null)
            {
                Functions.PlaySound(_explosionSound, 0.5f);
            }
        }

        private void ChangeScale()
        {
            float flippingDrection = Mathf.Sign(transform.localScale.x);
            transform.localScale += new Vector3(0.2f * flippingDrection, 0.05f, 0);
        }

        private void PlayBombExplosionEffect()
        {
            if (_explosionEffectPrefab != null)
            {
                Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerLaserGreen") ||
                collision.gameObject.CompareTag("PlayerBigLaser")
                )
            {
                _spriteRender.color = new Color32(255, 148, 170, 255);

                ChangeScale();

                StartCoroutine(Flashing());

                StartCoroutine(Explosion());

                _moveSpeed.Increase(1f);

            }


            foreach (var damageTarget in _damageTargets)
            {
                if (collision.gameObject.CompareTag(damageTarget.tag))
                {
                    Explpode();
                }

            }

        }

    }

}
