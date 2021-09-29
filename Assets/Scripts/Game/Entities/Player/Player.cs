using UnityEngine;
using Game.Abilities;
using Game.Damage;
using Game.Inputs;

namespace Game.Entities
{
    class Player : Entity
    {
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private float _meleeAttackDistance;
        [SerializeField] private int _meleeAttackDamage;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _wallCheckDistance;
        private IAbilityInput _abilityInput = new KeyBoardAbilityInput();
        private IMeleeAttackInput _meleeAttackInput = new KeyBoardMeleeAttackInput();

        protected override bool CanJump => GroundCollider.IsTouchingLayers() || IsTouchingWall();

        public void Initialize()
        {
            ShootInput.Shot += WeaponSlot.CurrentWeapon.Shoot;
            _abilityInput.AbilityUsed += OnAbilityUsed;
            _meleeAttackInput.MeleeAttackUsed += UseMeleeAttack;
        }

        private void OnAbilityUsed()
        {
            _ability.Use(transform);
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
            DirectionInput.ReadInput();
            ShootInput.ReadInput();
            
            _abilityInput.ReadInput();
            _meleeAttackInput.ReadInput();
            
            Move();
            Rotate();
            
            if (!TryJump())
                Slide();
        }
        
        protected void Slide()
        {
            var direction = DirectionInput.Direction;
            var canSlide = IsTouchingWall() && Rigidbody.velocity.y < _slideSpeed && direction.x != 0;

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