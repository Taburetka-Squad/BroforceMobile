using UnityEngine;

namespace Game.Projectiles.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : Projectile
    {
        private BulletData _data;

        private Rigidbody2D _rigidbody;

        private Vector2 _startPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(BulletData data)
        {
            _data = data;
            base.Initialize(data.Damage);
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
        
        private void Update()
        {
            var distance = Mathf.Abs(transform.position.x - _startPosition.x);
            var isOutOfRange = distance > _data.MaxDistance;

            if (isOutOfRange)
                ReturnToPool();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            TryDamageObject(collision.gameObject);
            ReturnToPool();
        }
    }
}