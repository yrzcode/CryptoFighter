using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

namespace CryptoFighter.n_Attack.Prejectile
{
    public class LaserController : ProjetctileController
    {
        [SerializeField] ProjectileConfig laserConfig;

        private PlayerPunk playerPunk;
        private Vector2 currentMousePostion;
        private PlayerInput playerInput;
        private Vector3 currentPlayerPosition;



        private void Awake()
        {
            playerInput = FindObjectOfType<PlayerInput>();
            playerPunk = FindObjectOfType<PlayerPunk>();

            currentMousePostion = GetCurrentMousePosition();
            currentPlayerPosition = playerPunk.transform.position;

        }

        private void Start()
        {
            HandleChildImageRotation();

            DestroyProjectile();

        }

        private void Update()
        {
            HandleProjectileMovement();

        }



        //handler
        private void HandleChildImageRotation()
        {
            float setoff = 90f;
            float angleToRotate = GetAimAngle(currentPlayerPosition,
                                         currentMousePostion) + setoff;

            transform.GetChild(0).Rotate(Vector3.forward,
                                         angleToRotate);
        }

        protected override void HandleProjectileMovement()
        {

            var moveDirection = (Vector3)currentMousePostion - currentPlayerPosition;

            var moveAmount = Vector3.ClampMagnitude(moveDirection,
                                                    laserConfig.GetProjectileSpeed() * Time.deltaTime);

            transform.Translate(moveAmount);
        }



        //function
        private float GetAimAngle(Vector3 p1, Vector3 p2)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }

        private Vector2 GetCurrentMousePosition()
        {

            //var mousePostion = playerInput.actions["GetMousePostion"].ReadValue<Vector2>();

            Vector2 mousePostion = playerPunk.input.InputActions.Player.GetMousePostion.ReadValue<Vector2>();

            return
            Camera.main.ScreenToWorldPoint(mousePostion);
        }



        //getter
        public ProjectileConfig GetPrejectileConfig() => laserConfig;


        //abstract

        protected override void DestroyProjectile()
        {
            Destroy(gameObject, laserConfig.GetWaitTimeToDestroy());
        }



        //collision

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag("Player")) return;

            PlayExplosionEffect();

            Destroy(gameObject);
        }

        private void PlayExplosionEffect()
        {
            Instantiate(laserConfig.GetLaserExplosionEffectPrefab(), transform.position, Quaternion.identity);
        }
    }
}




