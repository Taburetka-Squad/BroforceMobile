using Game.Health;
using Game.Weapons;
using UnityEngine;

namespace Game.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        protected WeaponSlot WeaponSlot => _weaponSlot;

        [Header("References")] [SerializeField]
        private WeaponSlot _weaponSlot;

        [SerializeField] private BoxCollider2D _groundCollider;
        [SerializeField] private EntityData _entityData;

        protected Health.Health _health;
        
        private Rigidbody2D _rigidbody;
        private bool _canJump;

        public void Initialize(EntityData data)
        {
            _entityData = data;
            _health = data.HealthData.GetInstance();
            _health.Died += OnDied;
            _weaponSlot = new WeaponSlot(data.WeaponData, transform);
        }

        public abstract void TakeDamage(int damage);
        
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

        protected abstract void OnDied();

    }
}