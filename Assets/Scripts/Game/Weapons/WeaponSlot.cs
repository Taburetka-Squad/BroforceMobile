using UnityEngine;

namespace Game.Weapons
{
    class WeaponSlot : MonoBehaviour
    {
        public Weapon CurrentWeapon { get; private set; }
        public bool HasWeapon => CurrentWeapon != null;

        [Header("References")]
        [SerializeField] WeaponData _startWeapon;

        private void Start()
        {
            if (_startWeapon == null) return;

            CurrentWeapon = _startWeapon.Spawn(transform);
        }
    }
}