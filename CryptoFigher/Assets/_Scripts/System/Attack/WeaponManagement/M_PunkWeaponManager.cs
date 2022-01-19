namespace System.Attack
{
    public class M_PunkWeaponManager : A_WeaponManager
    {
        private void Start()
        {
            foreach (var weapon in _weaponList) EnableWeapon(weapon);
        }
    }
}