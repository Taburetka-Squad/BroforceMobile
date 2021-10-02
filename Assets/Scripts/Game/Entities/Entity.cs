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
        [SerializeField] protected BoxCollider2D GroundCollider;
        [SerializeField] protected EntityData EntityData;

        [Header("Parameters")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _wallJumpDelay;

        protected abstract bool CanJump { get; }

        protected IDirectionInput DirectionInput = new KeyBoardDirectionInput();
        protected IShootInput ShootInput = new KeyBoardShootInput();
        protected Rigidbody2D Rigidbody;
        protected Health Health;

        private WeaponSlot _weaponSlot;
        private float _lastJumpTime;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Initialize(EntityData);
        }

        public abstract void TakeDamage(int damage);
        protected abstract void OnDied();

        public void Initialize(EntityData data)
        {
            EntityData = data;

            Health = data.HealthData.GetInstance();
            Health.Died += OnDied;

            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        protected void Move(Vector2 direction)
        {
            Debug.Log(direction);
            Rigidbody.velocity = new Vector2(direction.x * _speed, Rigidbody.velocity.y);
        }
        protected void Rotate(Vector2 direction)
        {
            if (direction.x == 0) return;

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