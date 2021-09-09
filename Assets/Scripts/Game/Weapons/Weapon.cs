using System.Collections;
using UnityEngine;

namespace Game.Weapons
{
    class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private WeaponData _data;
        private float _shootDelay;
        private float _lastShootTime;

        public void Initialize(WeaponData data)
        {
            _data = data;
            _shootDelay = 1 / _data.FireRate;
        }

        public void Shoot()
        {
            if (Time.time > _lastShootTime + _shootDelay)
            {
                var bullet = _data.BulletData.Spawn(_firePoint.position, _firePoint.rotation);

                bullet.Move(_firePoint.right);

                _lastShootTime = Time.time;
            }
        }
    }
}