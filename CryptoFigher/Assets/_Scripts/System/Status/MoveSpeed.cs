using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CryptoFighter.n_Status
{
    public class MoveSpeed : MonoBehaviour, IChangeableStatus
    {

        [SerializeField] float currentMoveSpeed;


        public float CurrentMoveSpeed { get => currentMoveSpeed; set => currentMoveSpeed = value; }



        public void Increase(float amount)
        {
            CurrentMoveSpeed += amount;
        }

        public void Decrease(float amount)
        {
            CurrentMoveSpeed -= amount;
        }
    }


}

