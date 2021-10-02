using UnityEngine;
using Game.Abilities;
using Game.Damage;

namespace Game.Entities
{
    class Player : Entity
    {
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private float _meleeAttackDistance;
        [SerializeField] private int _meleeAttackDamage;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _wallCheckDistance;

        protected override bool CanJump => GroundCollider.IsTouchingLayers() || IsTouchingWall();

        public override void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
        }

        protected override void OnDied()
        {
            Debug.Log("Player Died");
        }

        private void Update()
        {
            var horizontalDirection = Input.GetAxisRaw("Horizontal");
            var canJump = Input.GetKeyDown(KeyCode.Space);
            var canShoot = Input.GetMouseButton(0) && WeaponSlot.HasWeapon;

            Rotate(horizontalDirection);
            Move(horizontalDirection);

            if (canJump)
                Jump();
            else Slide(horizontalDirection);

            if (canShoot)
                WeaponSlot.CurrentWeapon.Shoot();

            if (Input.GetKeyDown(KeyCode.Mouse1))
                _ability.Use(transform);

            if (Input.GetKey(KeyCode.Q))
            {
                UseMeleeAttack();
            }
        }

        private void UseMeleeAttack()
        {
            var hit = Physics2D.Raycast(transform.position, transform.right, _meleeAttackDistance);

            if (hit.collider == null)
                return;
            
            if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_meleeAttackDamage);
            }
        }
        
        protected void Slide(float direction)
        {
            var canSlide = IsTouchingWall() && Rigidbody.velocity.y < _slideSpeed && direction != 0;

            if (canSlide)
                Rigidbody.velocity = new Vector2(0, _slideSpeed);
        }
        
        private bool IsTouchingWall()
        {
            var direction = transform.right;
            var collider = Physics2D.Raycast(transform.position, direction, _wallCheckDistance);
            
            return collider;
        }
    }
}