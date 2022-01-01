using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_Unit;


namespace CryptoFighter._ScaleChange
{
    public class RuningShrinker : MonoBehaviour
    {

        [SerializeField] Unit unit;
        [SerializeField] GameObject container;

        private PlayerPunk playerPunk;

        private float playerNormalScaleY;
        private float playerNormalScaleX;
        private Vector3 currentPlayerLocalScale;
        [SerializeField] private float shrinkAmout;
        [SerializeField] private float shrinkSpeed;
        [SerializeField] private float shrinkLimitY;
        private bool hasStartShrink;
        [SerializeField] private float shrinkSpeedX;

        public bool HasStartShrink { get => hasStartShrink; set => hasStartShrink = value; }
        public float ShrinkLimitY { get => shrinkLimitY; set => shrinkLimitY = value; }

        private void Awake()
        {
            playerPunk = GetComponent<PlayerPunk>();

        }

        private void Start()
        {
            currentPlayerLocalScale = playerPunk.PlayerImageContainer.localScale;
            playerNormalScaleY = currentPlayerLocalScale.y;
            playerNormalScaleX = currentPlayerLocalScale.x;
        }

        private void Update()
        {
            if (!HasStartShrink
                /*&& playerPunk.IsplayerEndRecoverMotion()*/
                && playerPunk.PlayerInputValue.x != 0
                && (playerPunk.IsPlayerFeetTouchingLayer(Layer.Ground)
                || playerPunk.IsPlayerFeetTouchingLayer(Layer.Box))
                && !playerPunk.IsPlayerTouchingWall())
            {


                StartCoroutine(PlayerRunShrink());
                HasStartShrink = true;
            }

        }


        private void SetPlayerLocalScale()
        {
            container.transform.localScale = currentPlayerLocalScale;
        }


        private IEnumerator PlayerRunShrink()
        {


            // ShrinkerBefore


            float preScaleForBeforeY = currentPlayerLocalScale.y;
            float shrinkedScaleY = preScaleForBeforeY;

            while (shrinkedScaleY > shrinkLimitY)
            {
                currentPlayerLocalScale -= Vector3.up * shrinkSpeed * Time.deltaTime;
                currentPlayerLocalScale += Vector3.right * shrinkSpeedX * Time.deltaTime;

                shrinkedScaleY = currentPlayerLocalScale.y;
                SetPlayerLocalScale();

                yield return null;

            }

            currentPlayerLocalScale = new Vector3(currentPlayerLocalScale.x, shrinkLimitY, currentPlayerLocalScale.z);
            SetPlayerLocalScale();


            yield return null;


            // ShrinkerHoldder


            while (playerPunk.PlayerInputValue.x != 0 && !playerPunk.IsPlayerTouchingWall())
            {
                container.transform.localScale =
        new Vector3(container.transform.localScale.x,
                    shrinkAmout,
                    container.transform.localScale.z);
                yield return null;
            }


            yield return null;



            // ShrinkerAfter

            float preScaleForAfterY = currentPlayerLocalScale.y;
            float recoveredScaleY = preScaleForAfterY;

            while (recoveredScaleY < playerNormalScaleY)
            {

                currentPlayerLocalScale += Vector3.up * shrinkSpeed * Time.deltaTime;
                currentPlayerLocalScale -= Vector3.right * shrinkSpeedX * Time.deltaTime;

                recoveredScaleY = currentPlayerLocalScale.y;
                SetPlayerLocalScale();

                yield return null;
            }

            currentPlayerLocalScale = new Vector3(playerNormalScaleX, playerNormalScaleY, currentPlayerLocalScale.z);
            SetPlayerLocalScale();


            HasStartShrink = false;


            yield break;
        }

    }
}

