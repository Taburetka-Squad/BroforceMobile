using UnityEngine;

using Game.Pools;
using Game.Projectiles.Bullets;

namespace Game.Weapons
{
    public class ShootWeapon : IAttack
    {
        private Transform _firePoint;

        private BulletData _bulleData;
        private float _shootDelay;
        private float _lastShootTime;

        private Pool<Bullet> _bulletPool = new Pool<Bullet>();

        public ShootWeapon(ShootWeaponData data, Transform firePoint)
        {
            _bulleData = data.BulletData;
            _firePoint = firePoint;
            _shootDelay = 1 / data.FireRate;
        }

        public void Attack()
        {
            Shoot();
        }
        private void Shoot()
        {
            var elapsedTime = Time.time - _lastShootTime;
            var canShoot = elapsedTime > _shootDelay;

            if (canShoot == false) return;
            _lastShootTime = Time.time;

            var bullet = GetBullet();
            bullet.Initialize(_firePoint);
        }

        private Bullet GetBullet()
        {
            if (_bulletPool.HasInactiveObjects())
                return _bulletPool.GetInactiveObject();

            var bullet = _bulleData.CreateInstance();
            _bulletPool.Add(bullet);

            return bullet;
        }
    }
}
