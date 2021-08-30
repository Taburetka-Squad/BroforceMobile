using UnityEngine;

namespace Game.Weapons
{
    class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private WeaponData _data;

        public void Initialize(WeaponData data)
        {
            _data = data;
        }

        public void Shoot()
        {
            // TODO
        }
    }
}