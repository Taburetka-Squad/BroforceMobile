using Game.Pools;
using Game.Weapons.Bullets;
using UnityEngine;

namespace Game.Weapons
{
    class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private WeaponData _data;
        private float _shootDelay;
        private float _lastShootTime;
        private Pool<Bullet> _pool;

        public void Initialize(WeaponData data)
        {
            _data = data;
            _shootDelay = 1 / _data.FireRate;
            _pool = new Pool<Bullet>();
        }

        public void Shoot()
        {
            if (Time.time > _lastShootTime + _shootDelay)
            {
                if (!_pool.TryGetInactiveObject(out var bullet))
                {
                    bullet = _data.BulletData.CreateBullet();
                    _pool.AddObjectToPool(bullet);
                }

                bullet.EnableInitialization(_firePoint.position, _firePoint.rotation);

                bullet.Move(_firePoint.right);

                _lastShootTime = Time.time;
            }
        }
    }
}