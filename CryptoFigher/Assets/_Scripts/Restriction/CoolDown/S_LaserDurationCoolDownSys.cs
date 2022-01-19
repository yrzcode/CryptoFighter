using System;
using CryptoFighter.n_Instaniate;
using UnityEngine;

namespace CryptoFighter.n_Restriction
{
    public class S_LaserDurationCoolDownSys : A_CoolDownSys
    {
        [SerializeField] S_InputBaseSpawnSystem _inputBaseSpawnSystem;

        protected override void Update()
        {
            if (!IsCoolDown)
            {
                DurationTimer =  _inputBaseSpawnSystem.IsSpawn? DurationTimer + Time.deltaTime : DurationTimer - Time.deltaTime;
            }
            
            base.Update();
        }
    }
}