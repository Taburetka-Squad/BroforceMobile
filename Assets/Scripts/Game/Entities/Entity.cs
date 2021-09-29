using DefaultNamespace;
using UnityEngine;
using Game.Weapons;
using Game.Damage;
using Game.Healths;
using Game.Inputs;

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
        protected IDirectionInput DirectionInput;
        protected IShootInput ShootInput;
        
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

        protected void Move()
        {
            var direction = DirectionInput.Direction;
            Rigidbody.velocity = new Vector2(direction.x * _speed, Rigidbody.velocity.y);
        }
        protected void Rotate()
        {
            var direction = DirectionInput.Direction;
            if (direction.x == 0) return;

            transform.right = Vector2.right * direction;
        }
        protected bool TryJump()
        {
            var isTimeOver = Time.time > _lastJumpTime + _wallJumpDelay;

            if (isTimeOver && CanJump)
            {
                _lastJumpTime = Time.time;
                Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                return true;
            }

            return false;
        }
    }
}