using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CryptoFighter.n_InputSystem;
using CryptoFighter.n_Unit.n_Player;
using Random = UnityEngine.Random;


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

        private static Camera _camera;
        public static Camera Camera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }

        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDic = new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds GetWait(float time)
        {
            if (WaitForSecondsDic.TryGetValue(time,out var wait)) return wait;
            WaitForSecondsDic[time] = new WaitForSeconds(time);
            return WaitForSecondsDic[time];
        }

        private static InputSystemBaseController _inputSystemBaseController;
        public static InputSystemBaseController InputController
        {
            get
            {
                if (_inputSystemBaseController == null) _inputSystemBaseController = FindObjectOfType<InputSystemBaseController>();
                return _inputSystemBaseController;
            }
        }
        
        const float PlayerNormalGravity = 10;
        
        public static Vector2 GetMouseWorldPos()
        {
            InputSystemBaseController input = InputController;
            Vector3 mousePos = input.GetInputAction().Player.GetMousePostion.ReadValue<Vector2>();
            return
            Camera.ScreenToWorldPoint(mousePos);

        }
        
        public static float GetAimAngle(Vector3 p1, Vector3 p2)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }

        public static Vector3 GetMoveDirection(Vector3 targetPos, Vector3 position)
        {
            var heading = targetPos - position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            
            return direction;
        }
        

        public static void FlipGameObject(GameObject gameObject)
        {
            var localScale = gameObject.transform.localScale;
            localScale = new Vector3(-localScale.x,localScale.y,localScale.z);
            gameObject.transform.localScale = localScale;
        }

        public static float GetPlayerNormalGravity() => PlayerNormalGravity;

        public static Vector3 GetRandPosInScreen(Vector2 boundaryMin, Vector2 boundaryMax)
        {
            Vector3 center = Camera.transform.position;
            
            var boundaryMinX = boundaryMin.x;
            var boundaryMaxX = boundaryMax.x;
            
            var boundaryMinY =boundaryMin.y;
            var boundaryMaxY = boundaryMax.y;
                

            float randXRight = center.x + Random.Range(boundaryMinX, boundaryMaxX);
            float randXLeft = center.x + Random.Range(-boundaryMinX, -boundaryMaxX);
            float[] randX = {randXLeft, randXRight}; 
            
            float randYRight = center.y + Random.Range(boundaryMinY, boundaryMaxY);
            float randYLeft = center.y + Random.Range(-boundaryMinY, -boundaryMaxY);

            float[] randY = {randYRight, randYLeft};
            
            return new Vector3(randX[Random.Range(0,randX.Length)], randY[Random.Range(0,randY.Length)]);
        }

        public static float GetMousePointDirection() => Mathf.Sign(GetMouseWorldPos().x - FindObjectOfType<Player>().transform.position.x);

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
        }

        public static T GetRandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(Random.Range(0,v.Length));
        }
        

        public static void PlaySound(AudioClip sound, float volume)
        {
            AudioSource.PlayClipAtPoint(sound, Camera.transform.position, volume);
        }

        public static void PlayEffect(GameObject effectPrefab, Vector3 effectPos, float duration)
        {
            if (effectPrefab != null)
            {
                GameObject effect = Instantiate(effectPrefab, effectPos, effectPrefab.transform.rotation);
                Destroy(effect, duration);
            }
        }

        

        public static bool IsColliderTouchingLayer(BoxCollider2D boxCollider2D,List<string> layerNames)
        {
            var result = false;
            foreach (var layName in layerNames)
            {
                var isTouch = boxCollider2D.IsTouchingLayers(LayerMask.GetMask(layName));
                if (isTouch) result = true;
            }
            return result;
        }
        public static bool IsColliderTouchingLayer(CircleCollider2D circleCollider2D,List<string> layerNames)
        {
            var result = false;
            foreach (var layName in layerNames)
            {
                var isTouch = circleCollider2D.IsTouchingLayers(LayerMask.GetMask(layName));
                if (isTouch) result = true;
            }
            return result;
        }
        public static bool IsColliderTouchingLayer(CapsuleCollider2D capsuleCollider2D,List<string> layerNames)
        {
            var result = false;
            foreach (var layName in layerNames)
            {
                var isTouch = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask(layName));
                if (isTouch) result = true;
            }
            return result;
        }

    }

}


