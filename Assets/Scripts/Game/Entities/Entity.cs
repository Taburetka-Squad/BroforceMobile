using UnityEngine;

using Game.Weapons;
using Game.Health;

namespace Game.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        protected WeaponSlot WeaponSlot => _weaponSlot;

        [Header("References")]
        [SerializeField] private BoxCollider2D _groundCollider;
        [SerializeField] private EntityData _entityData;

        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _wallJumpDelay;
        [SerializeField] private float _wallCheckDistance;

        private WeaponSlot _weaponSlot;
        protected Health.Health _health;

        private Rigidbody2D _rigidbody;
        private bool _isRotated;
        private float _lastWallJumpTime;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Initialize(_entityData);
        }

        public void Initialize(EntityData data)
        {
            _entityData = data;

            _health = data.HealthData.GetInstance();
            _health.Died += OnDied;

            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        public abstract void TakeDamage(int damage);
        protected abstract void OnDied();

        protected void Move(float direction)
        {
            var movement = new Vector2(direction, 0);

            _rigidbody.velocity = new Vector2(movement.x * _speed, _rigidbody.velocity.y);
        }
        protected void Jump()
        {
            var _onGround = _groundCollider.IsTouchingLayers();
            var isTimeOver = Time.time > _lastWallJumpTime + _wallJumpDelay;
            var canJump = isTimeOver ? _onGround || IsTouchingWall() : _onGround;

            _lastWallJumpTime = Time.time;

            if (canJump)
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        protected void Rotate(float direction)
        {
            if (direction == 0) return;

            _isRotated = direction < 0;

            transform.right = Vector2.right * direction;
            //transform.right = _rigidbody.velocity.normalized;
        }
        protected void Slide()
        {
            if (IsTouchingWall() && _rigidbody.velocity.y < _slideSpeed)
                _rigidbody.velocity = new Vector2(0, _slideSpeed);
        }

        private bool IsTouchingWall()
        {
            var direction = _isRotated ? Vector2.left : Vector2.right;
            var collider = Physics2D.Raycast(transform.position, direction, _wallCheckDistance);

            Debug.DrawRay(transform.position, direction, Color.red);

            return collider;
        }
    }
}