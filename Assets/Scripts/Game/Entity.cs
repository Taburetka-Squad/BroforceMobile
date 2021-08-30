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
        [Header("Parameters")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rigidbody;
        private const float raycastDistance = 1;

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
            RaycastHit2D raycastResult = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance); ;

            if(raycastResult.collider != null)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
}