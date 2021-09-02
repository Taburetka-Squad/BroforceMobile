using UnityEngine;

namespace Game.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    class Bullet : MonoBehaviour
    {
        private BulletData _data;
        private Rigidbody2D _rigidbody;

        public void Initialize(BulletData data)
        {
            _data = data;
            _rigidbody = GetComponent<Rigidbody2D>();

            Move();
        }
        private void Move()
        {
            _rigidbody.velocity = Vector2.right * _data.Speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this);
            // TODO
        }
    }
}