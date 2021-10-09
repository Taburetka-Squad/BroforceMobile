using UnityEngine;

using Game.Pools;
using Game.Projectiles.Bullets;

namespace Game.Weapons
{
    public class ShootAttack : IAttack
    {
        private readonly ShootScriptableAttack _data;
        private readonly Transform _firePoint;

        private float _lastShootTime;
        private readonly Pool<Bullet> _bulletPool = new Pool<Bullet>();

        public ShootAttack(ShootScriptableAttack data, Transform firePoint)
        {
            _data = data;

            _firePoint = firePoint;
        }

        private float ShootDelay => 1f / _data.FireRate;

        public void Attack()
        {
            Shoot();
        }
        private void Shoot()
        {
            var elapsedTime = Time.time - _lastShootTime;
            var canShoot = elapsedTime > ShootDelay;

            if (canShoot == false) return;
            _lastShootTime = Time.time;

            var bullet = GetBullet();
            bullet.Initialize(_firePoint);
        }

        private Bullet GetBullet()
        {
            if (_bulletPool.HasInactiveObjects())
                return _bulletPool.GetInactiveObject();

            var bullet = _data.BulletData.CreateInstance();
            _bulletPool.Add(bullet);

            return bullet;
        }
    }
}
