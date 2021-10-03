using System.Collections;
using DefaultNamespace;
using UnityEngine;
using Game.Weapons;
using Game.Healths;
using Game.Inputs;

namespace Game.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Health))]
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] 
        protected BoxCollider2D GroundCollider;

        protected WeaponSlot WeaponSlot => _weaponSlot;
        
        private float _speed;
        private float _jumpForce;
        private float _jumpDelay;

        protected abstract bool CanJump { get; }
        private float _lastJumpTime;
        protected IDirectionInput DirectionInput = new KeyBoardDirectionInput();
        protected IShootInput ShootInput = new KeyBoardShootInput();
        
        protected Rigidbody2D Rigidbody;
        private Health _health;
        private WeaponSlot _weaponSlot;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            _health = GetComponent<Health>();
        }
        
        public void Initialize(EntityData data)
        {
            _speed = data.Speed;
            _jumpForce = data.JumpForce;
            _jumpDelay = data.JumpDelay;
            
            _health.Died += OnDied;

            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        private void OnDied()
        {
            _health.Died -= OnDied;
            Die();
        }

        protected abstract void Die();

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
        protected void Jump()
        {
            var isTimeOver = Time.time > _lastJumpTime + _jumpDelay;

            if (isTimeOver && CanJump)
            {
                _lastJumpTime = Time.time;
                Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}