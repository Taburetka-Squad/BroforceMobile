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
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _raycastDistance;

        private Rigidbody2D _rigidbody;
        private bool _onGround;
        private bool _isRotated;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _onGround = true;
        }

        protected void Move(float direction)
        {
            Vector2 movement = new Vector2(direction, 0);

            _rigidbody.velocity = new Vector2(movement.x * _speed, _rigidbody.velocity.y);
        }
        protected void Jump()
        {
            var canJump = _onGround || IsTouchWall();
            _onGround = false;

            if (canJump)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
        protected void Rotate(float direction)
        {
            if (direction == 0) return;

            var isFlip = direction < 0;
            var flipRotation = new Quaternion(0, 180, 0, 0);

            _isRotated = isFlip;
            transform.rotation = isFlip ? flipRotation : Quaternion.identity;
        }

        private bool IsTouchWall()
        {
            var direction = _isRotated ? Vector2.left : Vector2.right;
            var collider = Physics2D.Raycast(transform.position, direction, _raycastDistance);
            
            Debug.DrawRay(transform.position, direction, Color.red);

            return collider;
        }
    }
}