using DefaultNamespace;
using UnityEngine;
using Game.Healths;
using Game.Inputs.DirectionInput;
using Input = Game.Inputs.Input;

namespace Game.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        public Health Health { get; private set; }

        [SerializeField] protected BoxCollider2D GroundCollider;

        protected Input Input;
        protected IDirectionInput DirectionInput;

        private float _speed;
        private float _jumpForce;
        private float _jumpDelay;

        protected abstract bool CanJump { get; }

        protected Rigidbody2D Rigidbody;

        private float _lastJumpTime;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(EntityData data)
        {
            Input = new Input();
            Input.AddInputToUpdateQueue(DirectionInput);
            
            _speed = data.Speed;
            _jumpForce = data.JumpForce;
            _jumpDelay = data.JumpDelay;

            Health = new Health(data.BaseHitPoints);
            Health.Died += OnDied;
        }

        private void OnDied()
        {
            Health.Died -= OnDied;
            Die();
        }

        protected abstract void Die();

        protected void Move(Vector2 direction)
        {
            Rigidbody.velocity = new Vector2(direction.x * _speed, Rigidbody.velocity.y);
        }

        protected void Rotate(Vector2 direction)
        {
            if (direction.x == 0) return;

            transform.right = Vector2.right * direction.x;
        }

        protected void Jump()
        {
            var isTimeOver = Time.time > _lastJumpTime + _jumpDelay;

            if (isTimeOver && CanJump)
            {
                _lastJumpTime = Time.time;
                Rigidbody.velocity = Vector2.up * _jumpForce;
            }
        }
    }
}