using DefaultNamespace;
using UnityEngine;
using Game.Weapons;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour
    {
        protected WeaponSlot WeaponSlot => _weaponSlot;

        [Header("References")] [SerializeField]
        private WeaponSlot _weaponSlot;

        [SerializeField] private BoxCollider2D _groundCollider;
        [SerializeField] private EntityData _entityData;

        private Rigidbody2D _rigidbody;
        private bool _canJump;

        public void Initialize(EntityData data)
        {
            _entityData = data;
            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        private void Awake()
        {
            Initialize(_entityData);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _canJump = true;
        }

        protected void Move(float direction)
        {
            var movement = new Vector2(direction, 0);

            _rigidbody.velocity = new Vector2(movement.x * _entityData.Speed, _rigidbody.velocity.y);
        }

        protected void Jump()
        {
            if (_canJump)
            {
                _rigidbody.AddForce(Vector2.up * _entityData.JumpForce, ForceMode2D.Impulse);

                _canJump = false;
            }
        }
    }
}