using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CryptoFighter.n_Attack.Prejectile
{
    public class BigLaserController : MonoBehaviour
    {
        [SerializeField] private float bigLaserSpeed;
        private Vector3 direction;
        private Vector3 moveAmount;

        // Start is called before the first frame update
        void Start()
        {

            var mousePos = Functions.GetMouseWorldPos();
            direction = new Vector3(mousePos.x, mousePos.y, 0) - FindObjectOfType<PlayerPunk>().transform.position;
            moveAmount = Vector3.ClampMagnitude(direction, 1);

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(moveAmount * bigLaserSpeed * Time.deltaTime);

        }
    }
}



