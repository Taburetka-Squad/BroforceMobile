using Game.Abilities;
using Game.Healths;
using UnityEngine;

namespace Game.Entities
{
    public class Bro : Entity
    {
        private const float WallCheckDistance = 0.6f;
        private const float MeleeAttackDistance = 0.6f;
        
        private IAbility _ability;

        private float _hitDelay;
        private float _slideSpeed;
        private int _meleeAttackDamage;
        
        private float _lastHitTime;

        protected override bool CanJump =>
            DirectionInput.Direction.x != 0
            && IsTouchingWall()
            || GroundCollider.IsTouchingLayers();


        public void Initialize(BroData data)
        {
            base.Initialize(data);

            _hitDelay = 1 / data.Speed;
            _ability = data.Ability;
            _slideSpeed = data.SlideSpeed;
            _meleeAttackDamage = data.MeleeAttackDamage;
        }

        private void UseAbility()
        {
            _ability.Use(transform);
        }
        private void UseMeleeAttack()
        {
            var elapsedTime = Time.time - _lastHitTime;
            var canHit = elapsedTime > _hitDelay;

            if (canHit == false) return;
            _lastHitTime = Time.time;
        
            var hit = Physics2D.Raycast(transform.position, transform.right, MeleeAttackDistance);


            if (hit.collider == null)
                return;
            if (hit.collider.TryGetComponent(out Health damageable))
            {
                damageable.TakeDamage(_meleeAttackDamage);
            }
        }
        
        protected override void Die()
        {
            Debug.Log("Bro Died");
        }

        private void Update()
        {
            if (ShootInput.CanShoot)
            {
                WeaponSlot.CurrentWeapon.Shoot();
            }
            
            if (Input.GetKey(KeyCode.Q))
            {
                UseMeleeAttack();
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                UseAbility();
            }
            
            Move();

            Rotate();
            if (DirectionInput.Direction.y > 0)
                Jump();
            else
                Slide();
            
        }


        private bool IsTouchingWall()
        {
            var direction = transform.right;

            var collider = Physics2D.Raycast(transform.position, direction, WallCheckDistance);
            return collider;
        }
        private void Slide()
        {
            var direction = DirectionInput.Direction;
            var canSlide = IsTouchingWall() && Rigidbody.velocity.y < _slideSpeed && direction.x != 0;
            if (canSlide) Rigidbody.velocity = new Vector2(0, _slideSpeed);
        }
    }
}