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

        private Rigidbody2D _rigidbody;
        private bool _canJump;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _canJump = true;
        }

        protected void Move(float direction)
        {
            Vector2 movement = new Vector2(direction, 0);

            _rigidbody.velocity = new Vector2(movement.x * _speed, _rigidbody.velocity.y);
        }
        protected void Jump()
        {
            if(_canJump)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce);

                _canJump = false;
            }
        }
    }
}