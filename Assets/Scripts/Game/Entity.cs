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

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected void Move(float direction)
        {
            // TODO
        }
        protected void Jump()
        {
            // TODO
        }
    }
}