using UnityEngine;

using Game.Pools;
using Game.Damage;

namespace Game.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(DamageDealer))]
    public class Bullet : PooledObject
    {
        private BulletData _data;

        private Rigidbody2D _rigidbody;
        private DamageDealer _damageDealer;

        private Vector2 _startPosition;

        private void Awake()
        {
            _damageDealer = GetComponent<DamageDealer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(BulletData data)
        {
            _data = data;
            _damageDealer.Initialize(data.Damage);
        }
        public void Initialize(Transform firePoint)
        {
            transform.position = firePoint.position;
            transform.rotation = firePoint.rotation;

            StartMove(firePoint.right);
        }

        private void StartMove(Vector2 direction)
        {
            _startPosition = transform.position;
            _rigidbody.velocity = direction * _data.Speed;
        }
        
        private void FixedUpdate()
        {
            var distance = Mathf.Abs(transform.position.x - _startPosition.x);
            var isOutOfRange = distance > _data.MaxDistance;

            if (isOutOfRange)
                ReturnToPool();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPool();
        }
    }
}