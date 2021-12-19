using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseShooter : Shooter
{

    [SerializeField] private GameObject projectilePrafab;
    [SerializeField] private GameObject fireEffectPrefab;

    private Animator _animator;
    private PlayerInput _playerInput;
    private PlayerPunk playerPunk;
    private bool isPlayerLaserShooting;
    [SerializeField] private float reduceHealth;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();

        _playerInput = GetComponent<PlayerInput>();

         playerPunk = FindObjectOfType<PlayerPunk>();
    }


    //handler

    protected override void HandleShooting()
    {

        if (playerPunk.IsPlayerTouchingWall()) return;

        HandlePlayerFlipping();

        PlayLaserAttakAnime();

        GenerateProjectile();

        playerPunk.UpdatePlayerCurrentHealth(reduceHealth);

        PlayFireEffect();

        PlayShootSound();

        StartCoroutine(HandlePlayerFlipping());
    }

    private void PlayFireEffect()
    {
        Vector3 offset = new Vector3(0, 0.5f, -1f);

        Instantiate(fireEffectPrefab,
                    transform.position + offset,
                    Quaternion.Euler(180f,0,0));
    }

    private void GenerateProjectile()
    {
        Vector3 offset = Vector3.up * 0.3f;

        Instantiate(projectilePrafab,
                    transform.position + offset,
                    Quaternion.identity);
    }

    private IEnumerator HandlePlayerFlipping()
    {

        isPlayerLaserShooting = true;

        float clickMousePositionX = GetCurrentMousePosition().x;


        float localScaleX = Mathf.Sign(clickMousePositionX - transform.position.x);


        transform.localScale = new Vector3(localScaleX, 1f, 1f);

        yield return new WaitForSeconds(0.5f);

        isPlayerLaserShooting = false;
    }

    private void PlayLaserAttakAnime()
    {
        _animator.Play("Base Layer.PlayerLaserAttacking");
    }



    //function
    private Vector2 GetCurrentMousePosition()
    {

        var mousePostion = _playerInput.actions["GetMousePostion"].ReadValue<Vector2>();

        return
        Camera.main.ScreenToWorldPoint(mousePostion);
    }



    // getter
    public bool IsPlayerLaserShooting() => isPlayerLaserShooting;



}
