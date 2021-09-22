using UnityEngine;

namespace Game.Weapons
{
    public class WeaponSlot 
    {
        public Weapon CurrentWeapon { get; }
        public bool HasWeapon => CurrentWeapon != null;

        public WeaponSlot(WeaponData weaponData, Transform parent)
        {
            CurrentWeapon = weaponData.CreateInstance(parent);
        }
    }
}