using UnityEngine;

namespace Game.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    class Bullet : MonoBehaviour
    {
        private BulletData _data;
        private Rigidbody2D _rigidbody;
        private Vector3 _startPosition;

        public void Initialize(BulletData data)
        {
            _data = data;
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _data.Speed;
        }

        private void Start()
        {
            _startPosition = transform.position;
        }
        private void FixedUpdate()
        {
            if(Mathf.Abs(transform.position.x) > Mathf.Abs(_startPosition.x) + _data.LifeDistance)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
            // TODO
        }
    }
}