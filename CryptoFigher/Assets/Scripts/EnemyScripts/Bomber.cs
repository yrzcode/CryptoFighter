using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private BombEnemy _bombEnemy;
    private int takeDamage;
    [SerializeField] private int bombCount;
    [SerializeField] private float bombCountDownTime;
    [SerializeField] private GameObject bombExplosionEffectPrefab;

    private void Awake()
    {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        _bombEnemy = GetComponent<BombEnemy>();
    }

    private void Update()
    {
        if (takeDamage > bombCount)
        {
            PlayBombExplosionEffect();

            Destroy(gameObject);
        }
    }

    private IEnumerator Explosion()
    {

        yield return new WaitForSeconds(bombCountDownTime);

        PlayBombExplosionEffect();

        Destroy(gameObject);

    }

    public void ExplpodeInmediately()
    {
        PlayBombExplosionEffect();

        Destroy(gameObject);
    }

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

    private void PlayBombExplosionEffect()
    {
        Instantiate(bombExplosionEffectPrefab, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaserGreen"))
        {

            float flippingDrection = Mathf.Sign(transform.localScale.x);

            transform.localScale += new Vector3(0.2f * flippingDrection, 0.2f, 0);

            _spriteRender.color = new Color32(255, 148, 170, 255);

            StartCoroutine(Flashing());

            TakeDamage(1);
        }
    }

    private void TakeDamage(int v)
    {
        takeDamage += v;
        _bombEnemy.UpdateBombEnmeyMoveSpeed(1f); 
        StartCoroutine(Explosion());

    }
}
