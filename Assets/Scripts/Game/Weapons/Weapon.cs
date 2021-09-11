using UnityEngine;

using Game.Pools;
using Game.Weapons.Bullets;

namespace Game.Weapons
{
    class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private WeaponData _data;
        private float _shootDelay;
        private float _lastShootTime;

        private Pool<Bullet> _bulletPool = new Pool<Bullet>();

        public void Initialize(WeaponData data)
        {
            _data = data;
            _shootDelay = 1 / _data.FireRate;
        }

        public void Shoot()
        {
            var elapsedTime = Time.time - _lastShootTime;
            var canShoot = elapsedTime > _shootDelay;

            if (canShoot == false) return;
            else _lastShootTime = Time.time;

            var bullet = GetBullet();
            bullet.Initialize(_firePoint);
        }
        private Bullet GetBullet()
        {
            if (_bulletPool.HasInactiveObjects())
                return _bulletPool.GetInactiveObject();

            var bullet = _data.BulletData.Spawn();
            _bulletPool.Add(bullet);

            return bullet;
        }
    }
}