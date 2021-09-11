using System;
using Game.Pools;
using UnityEngine;

namespace Game.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    class Bullet : PooledObject
    {
        public override event Action<PooledObject> Disabled;

        private BulletData _data;
        private Rigidbody2D _rigidbody;
        private Vector2 _startPosition;

        public void Initialize(BulletData data)
        {
            _data = data;
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void EnableInitialization(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
        
        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _data.Speed;
        }
        
        private void FixedUpdate()
        {
            if(Mathf.Abs(transform.position.x) > Mathf.Abs(_startPosition.x) + _data.LifeDistance)
            {
                Disable();
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Disable();
            // TODO
        }

        private void Disable()
        {
            Disabled?.Invoke(this);
        }

    }
}