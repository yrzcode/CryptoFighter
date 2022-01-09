using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Behavior
{
    public class Generator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float rotationY;
        float timer = 0;
        [SerializeField] private float ShootingSpeed;

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer > ShootingSpeed)
            {
                Generate();
                timer = 0;
            }

        }


        private void Generate()
        {

            //float rotationZ = transform.position.ToTargetAngle(Functions.GetMouseWorldPos());
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.Euler(0, rotationY, 0));
            //Instantiate(prefab, transform);

            //GameObject instance = Instantiate(prefab);


            instance.transform.parent = this.transform.parent;

        }
    }

}


