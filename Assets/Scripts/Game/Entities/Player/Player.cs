using UnityEngine;
using Game.Abilities;
using Game.Damage;
using Game.Inputs;

namespace Game.Entities
{
    class Player : Entity
    {
        [SerializeField] private ScriptableAbility _ability;
        [SerializeField] private int _hitRate;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _wallCheckDistance;
        [SerializeField] private float _meleeAttackDistance;
        [SerializeField] private int _meleeAttackDamage;

        private IAbilityInput _abilityInput = new KeyBoardAbilityInput();
        private IMeleeAttackInput _meleeAttackInput = new KeyBoardMeleeAttackInput();
        private float _hitDelay => 1 / _hitRate;
        private float _lastHitTime;

        protected override bool CanJump => GroundCollider.IsTouchingLayers() || IsTouchingWall();

        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            DirectionInput.ReadInput();
            ShootInput.ReadInput();
            _abilityInput.ReadInput();
            _meleeAttackInput.ReadInput();

            Move(DirectionInput.Direction);
            Rotate(DirectionInput.Direction);

            if (DirectionInput.Direction.y > 0)
                Jump();
            else
                Slide();
        }

        public void Initialize()
        {
            base.Initialize(EntityData);
            ShootInput.Shot += WeaponSlot.CurrentWeapon.Shoot;
            _abilityInput.AbilityUsed += OnAbilityUsed;
            _meleeAttackInput.MeleeAttackUsed += UseMeleeAttack;
        }
        public override void TakeDamage(int damage)
        {
            Health.TakeDamage(damage);
        }

        protected void Slide()
        {
            var direction = DirectionInput.Direction;

            var canSlide = IsTouchingWall() && Rigidbody.velocity.y < _slideSpeed && direction.x != 0;
            if (canSlide)
                Rigidbody.velocity = new Vector2(0, _slideSpeed);
        }
        protected override void OnDied()
        {
            Debug.Log("Player Died");
        }

        private void OnAbilityUsed()
        {
            _ability.Use(transform);
        }
        private void UseMeleeAttack()
        {
            var elapsedTime = Time.time - _lastHitTime;
            var canHit = elapsedTime > _hitDelay;

            if (canHit == false) return;
            _lastHitTime = Time.time;

            var hit = Physics2D.Raycast(transform.position, transform.right, _meleeAttackDistance);
            if (hit.collider == null)
                return;
            if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_meleeAttackDamage);
            }
        }
        private bool IsTouchingWall()
        {
            var direction = transform.right;

            var collider = Physics2D.Raycast(transform.position, direction, _wallCheckDistance);
            return collider;
        }
    }
}