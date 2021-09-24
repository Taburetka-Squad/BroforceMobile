using UnityEngine;
using Game.Weapons;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    abstract class Entity : MonoBehaviour
    {
        protected WeaponSlot WeaponSlot => _weaponSlot;

        [Header("References")]
        [SerializeField] private WeaponSlot _weaponSlot;
        [SerializeField] private BoxCollider2D _groundCollider;
        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _wallJumpDelay;
        [SerializeField] private float _wallCheckDistance;

        private Rigidbody2D _rigidbody;
        private bool _isRotated;
        private float _lastWallJumpTime;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected void Move(float direction)
        {
            Vector2 movement = new Vector2(direction, 0);

            _rigidbody.velocity = new Vector2(movement.x * _speed, _rigidbody.velocity.y);
        }
        protected void Jump()
        {
            var _onGround = _groundCollider.IsTouchingLayers();
            var isTimeOver = Time.time > _lastWallJumpTime + _wallJumpDelay;
            var canJump = isTimeOver ? _onGround || IsTouchingWall() : _onGround;

            _lastWallJumpTime = Time.time;

            if (canJump)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
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
            {
                _rigidbody.velocity = new Vector2(0, _slideSpeed);
            }
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