using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Attack.Prejectile
{
    public class BigLesarController : MonoBehaviour
    {
        [SerializeField] private float bigLesarSpeed;
        private Vector3 direction;
        private Vector3 moveAmount;

        // Start is called before the first frame update
        void Start()
        {

            var mousPos = Functions.GetMouseWorldPos();
            direction = new Vector3(mousPos.x, mousPos.y, 0) - FindObjectOfType<PlayerPunk>().transform.position;
            moveAmount = Vector3.ClampMagnitude(direction, 1);

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(moveAmount * bigLesarSpeed * Time.deltaTime);

        }
    }
}



