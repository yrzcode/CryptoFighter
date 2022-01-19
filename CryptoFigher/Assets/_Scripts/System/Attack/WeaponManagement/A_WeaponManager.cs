using System.Collections.Generic;
using UnityEngine;

namespace System.Attack
{
    public abstract class A_WeaponManager : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> _weaponList;

        public void EnableWeapon(GameObject weapon) => weapon.SetActive(true);
        public void DisableWeapon(GameObject weapon) => weapon.SetActive(false);
    }
}