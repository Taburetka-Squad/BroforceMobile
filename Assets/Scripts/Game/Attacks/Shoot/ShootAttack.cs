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
            TryShoot();
        }
        private void TryShoot()
        {
            var elapsedTime = Time.time - _lastShootTime;
            var canShoot = elapsedTime > ShootDelay;

            if (canShoot == false) return;
            _lastShootTime = Time.time;

            Shoot();
        }
        private void Shoot()
        {
            SpreadFirepoint();

            var bullet = GetBullet();
            bullet.Initialize(_firePoint);

            ResetFirepoint();
        }

        private void SpreadFirepoint()
        {
            var angle = Random.Range(-_data.SpreadAngle, _data.SpreadAngle);
            _firePoint.localRotation = Quaternion.Euler(0, 0, angle);
        }
        private void ResetFirepoint()
        {
            _firePoint.localRotation = Quaternion.identity;
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