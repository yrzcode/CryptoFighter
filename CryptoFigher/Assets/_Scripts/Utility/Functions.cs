using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_InputSystem;
using CryptoFighter.n_Unit.n_Player;

namespace CryptoFighter
{
    public class Functions : MonoBehaviour
    {
        //public static Functions Instance;

        //private void Awake()
        //{
        //    if (Instance != null)
        //    {
        //        Destroy(gameObject);
        //        return;
        //    }
        //    else
        //    {
        //        Instance = this;
        //        DontDestroyOnLoad(gameObject);
        //    }
        //}


        const float playerNormalGravity = 10;
        static Camera _camera = Camera.main;



        private void Start()
        {
            //playerNormalGravity = FindObjectOfType<Player>().GetComponent<Rigidbody2D>().gravityScale;
        }

        public static Vector2 GetMouseWorldPos()
        {
            InputSystemBaseController input = FindObjectOfType<InputSystemBaseController>();

            Vector3 mousePos = input.InputActions.Player.GetMousePostion.ReadValue<Vector2>();

            return
            Camera.main.ScreenToWorldPoint(mousePos);

        }


        public static float GetAimAngle(Vector3 p1, Vector3 p2)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }


        public static void FilpGameObject(GameObject gameObject)
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,
                                                           gameObject.transform.localScale.y,
                                                           gameObject.transform.localScale.z);
        }

        public static float GetPlayerNormalGravity()
        {
            return playerNormalGravity;
        }

        public static Vector3 GetRandPosInScreen(float bounaryX, float bounaryY)
        {
            Vector3 center = Camera.main.transform.position;

            float randX = center.x + Random.Range(-bounaryX, bounaryX);
            float randY = center.y + Random.Range(-bounaryY, bounaryY);

            return new Vector3(randX, randY, 0);
        }

        public static float GetMousePointDirection()
        {
            return
                Mathf.Sign(
                GetMouseWorldPos().x - FindObjectOfType<Player>().transform.position.x
                    );
        }


        public static IEnumerator Co_DisablePlayerControl(float time)
        {
            Player player = FindObjectOfType<Player>();
            float timer = 0;
            while (timer < time)
            {
                player.DisablePlayerInput();
                timer += Time.deltaTime;
                yield return null;

            }
            yield break;
        }

        public static void PlaySound(AudioClip sound, float volume)
        {
            AudioSource.PlayClipAtPoint(sound, _camera.transform.position, volume);
        }

        public static void PlayEffect(GameObject effectPrefab, GameObject effectpPos, Quaternion rotation, float duration)
        {
            GameObject effect = Instantiate(effectPrefab, effectpPos.transform.position, rotation);

            Destroy(effect, duration);
        }



    }

}


