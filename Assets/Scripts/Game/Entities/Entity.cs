using UnityEngine;
using Game.Weapons;
using Game.Damage;
using Game.Healths;

namespace Game.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        protected WeaponSlot WeaponSlot => _weaponSlot;

        [Header("References")]
        [SerializeField] 
        protected BoxCollider2D GroundCollider;
        [SerializeField] 
        private EntityData _entityData;

        [Header("Parameters")] 
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpForce;
        [SerializeField] 
        private float _wallJumpDelay;

        protected abstract bool CanJump { get; }
        private float _lastJumpTime;
        
        protected Rigidbody2D Rigidbody;
        protected Health Health;
        private WeaponSlot _weaponSlot;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Initialize(_entityData);
        }

        public void Initialize(EntityData data)
        {
            _entityData = data;

            Health = data.HealthData.GetInstance();
            Health.Died += OnDied;

            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        public abstract void TakeDamage(int damage);
        protected abstract void OnDied();

        protected void Move(float direction)
        {
            Rigidbody.velocity = new Vector2(direction * _speed, Rigidbody.velocity.y);
        }

        protected void Rotate(float direction)
        {
            if (direction == 0) return;

            transform.right = Vector2.right * direction;
        }

        protected void Jump()
        {
            var isTimeOver = Time.time > _lastJumpTime + _wallJumpDelay;

            if (isTimeOver && CanJump)
            {
                _lastJumpTime = Time.time;
                Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}